using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_users : MonoBehaviour
{
    private bool scoreSet = false;
    private List<Score> best_scores;
    public Text score_text;

    void Start()
    {
        GetComponent<GetPodium>().StartCoroutine("GetPodiumData");
    }

    void Update()
    {
        if (GetComponent<GetPodium>().scoreSet == true && scoreSet == false)
        {
            foreach (Score score in GetComponent<GetPodium>().best_scores)
            {
                score_text.text += $"{score.Winner} : {score.Value} \n \n";
            }
            scoreSet = true;
        }
    }
}
