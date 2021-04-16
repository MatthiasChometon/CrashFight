using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class GetStat : MonoBehaviour
{
    public bool statGet = false;
    private string data;
    public List<Warrior> warriors = new List<Warrior>();
    public IEnumerator GetStatData()
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

            foreach(GameObject warrior in GameObject.FindGameObjectsWithTag("Player")) {
                warrior.GetComponent<Warrior>().Life = JsonConvert.DeserializeObject<List<Stat>>(data)[0].Life;
            }

            statGet = true;
        }
    }
}