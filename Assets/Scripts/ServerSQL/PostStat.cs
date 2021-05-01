using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class PostStat : MonoBehaviour
{
    public Slider life_slider;
    public Slider round_slider;
    public Stat new_stat;

    void Start()
    {
        new_stat = new Stat((int)life_slider.value, (int)round_slider.value);
    }
    public void Update_stats()
    {
        new_stat.Life = (int)life_slider.value;
        new_stat.Round = (int)round_slider.value;
    }

    public IEnumerator Upload(string change_scene = "")
    {
        WWWForm form = new WWWForm();

        form.AddField("new_stats", JsonConvert.SerializeObject(new_stat));

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

        if (change_scene != "")
        {
            GetComponent<Change_scene>().LoadLevel();
        }
    }
}