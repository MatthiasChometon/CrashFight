using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class GetStat : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Get_stats_data");
    }
    private string data;
    public Stat stat;

    public IEnumerator Get_stats_data()
    {
        UnityWebRequest uwr = UnityWebRequest.Get("http://localhost:8000/GetStatData");
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError || uwr.isHttpError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            data = uwr.downloadHandler.text;
            stat = JsonConvert.DeserializeObject<List<Stat>>(data)[0];
            Set_stats();
        }
    }

    public void Set_stats()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length != 0 && GameObject.FindGameObjectsWithTag("statbar").Length != 0)
        {
            foreach (GameObject warrior in GameObject.FindGameObjectsWithTag("Player"))
            {
                warrior.GetComponent<Warrior>().Life = stat.Life;
            }

            foreach (GameObject warrior in GameObject.FindGameObjectsWithTag("statbar"))
            {
                warrior.GetComponent<statBar>().sliderHealth.maxValue = stat.Life;
            }
        }

        if(GameObject.FindGameObjectsWithTag("Player").Length != 0) {
            GameObject.FindGameObjectsWithTag("manager")[0].GetComponent<Win_manager>().round_for_win = stat.Round;
        }

        if (GameObject.FindGameObjectsWithTag("life_slider_option").Length != 0)
        {
            GameObject.FindGameObjectsWithTag("life_slider_option")[0].GetComponent<Slider>().value = stat.Life;
        }

        if (GameObject.FindGameObjectsWithTag("round_slider_option").Length != 0)
        {
            GameObject.FindGameObjectsWithTag("round_slider_option")[0].GetComponent<Slider>().value = stat.Round;
        }
    }

}