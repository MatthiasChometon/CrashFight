﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class GetPodium : MonoBehaviour
{
    public bool usersGet = false;
    private string data;
    public List<User> users = new List<User>();
    public IEnumerator GetPodiumData()
    {
        UnityWebRequest uwr = UnityWebRequest.Get("http://localhost:8000/GetPodiumData");
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError || uwr.isHttpError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            data = uwr.downloadHandler.text;

            users = JsonConvert.DeserializeObject<List<User>>(data);

            usersGet = true;
        }
    }
}