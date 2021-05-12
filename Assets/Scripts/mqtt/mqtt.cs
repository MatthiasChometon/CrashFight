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

    private MqttClient client;
    // Use this for initialization
    void Start()
    {
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

        if (e.Topic == "command/1")
        {
            Debug.Log("Received: 1 " + System.Text.Encoding.UTF8.GetString(e.Message));
        }

        if (e.Topic == "command/2")
        {
            Debug.Log("Received: 2 " + System.Text.Encoding.UTF8.GetString(e.Message));
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
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 80, 20), "Level 1"))
        {
            client.Publish("hello/world", System.Text.Encoding.UTF8.GetBytes("Sending from Unity3D!!!"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
    }
    // Update is called once per frame
    void Update()
    {



    }


}