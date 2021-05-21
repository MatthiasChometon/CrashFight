using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System;
using System.Collections.Generic;

public class mqtt : MonoBehaviour
{
    public List<String> PlayersId;
    public String[] PlayersCommands = new String[4];

    private user_management user_manager;

    private MqttClient client;
    // Use this for initialization
    void Start()
    {
        user_manager = GameObject.FindGameObjectsWithTag("user_manager")[0].GetComponent<user_management>();
        if (GameObject.FindGameObjectsWithTag("commands_manager").Length == 1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        // create client instance 
        client = new MqttClient(IPAddress.Parse("51.158.79.224"), 1883, false, null);

        // register to message received 
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId);

        // subscribe to the topic "/home/temperature" with QoS 2 
        client.Subscribe(new string[] { "connect" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

    }
    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {

        //Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));

        if (e.Topic == "connect")
        {
            Debug.Log("connect");
            connectToJoyStick(e);
        }

        for (int i = 1; i <= PlayersId.Count; i++)
        {
            if (e.Topic == "command/" + i)
            {
                PlayersCommands[i - 1] = System.Text.Encoding.UTF8.GetString(e.Message);
            }
        }

    }

    void connectToJoyStick(MqttMsgPublishEventArgs e)
    {
        PlayersId.Add(System.Text.Encoding.UTF8.GetString(e.Message));

        int Id = PlayersId.Count;

        Debug.Log(Id);
        Debug.Log("joystick/" + System.Text.Encoding.UTF8.GetString(e.Message));

        client.Publish("joystick/" + System.Text.Encoding.UTF8.GetString(e.Message), System.Text.Encoding.UTF8.GetBytes(Id.ToString()), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        client.Subscribe(new string[] { "command/" + Id.ToString() }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        user_manager.players.Add(new Player(Id, "", ""));
    }

}