﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class PostPodium : MonoBehaviour
{
    public IEnumerator UploadPodium(Score score, string change_scene = "")
    {
        WWWForm form = new WWWForm();

        form.AddField("score", JsonConvert.SerializeObject(score));

        Debug.Log(JsonConvert.SerializeObject(score));

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/SendPodiumData", form);
        yield return www.SendWebRequest();

    }
}
