using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class PostStat : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();

        Stat new_stat = new Stat(200, 2);
        form.AddField("new_stats", new_stat.ToString());

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/SendStatData", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}