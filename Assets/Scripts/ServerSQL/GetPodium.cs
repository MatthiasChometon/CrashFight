using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetPodium
{

    public Text Id;
    public Text Pseudo;
    public Text Score;
    private string data;
    public string[] userData;


    IEnumerator GetPodiumData()
    {
        UnityWebRequest uwr = UnityWebRequest.Get("http://localhost:8000/GetPodiumData?=Pseudo" + Pseudo.text);
        yield return uwr.SendWebRequest();

        Debug.Log(Pseudo.text);

        if (uwr.isNetworkError || uwr.isHttpError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            data = uwr.downloadHandler.text;
            
            Pseudo.text = userData[1];
            Score.text = userData[2];

        }
    }
}