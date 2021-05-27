using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class GetPodium : MonoBehaviour
{
    public bool scoreSet = false;
    private string data;
    public List<Score> best_scores = new List<Score>();
    public IEnumerator GetPodiumData()
    {
        UnityWebRequest uwr = UnityWebRequest.Get("http://localhost:8000/GetPodiumData");
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError || uwr.isHttpError)
        {
       
        }
        else
        {
            data = uwr.downloadHandler.text;

            best_scores = JsonConvert.DeserializeObject<List<Score>>(data);

            scoreSet = true;
        }
    }
}