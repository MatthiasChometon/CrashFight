using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_users : MonoBehaviour
{

    private bool scoreSet = false;
    private List<Score> best_scores;
    public GameObject score;

    void Start()
    {
        GetComponent<GetPodium>().StartCoroutine("GetPodiumData");
    }

    void Update()
    {
        Text score_text = score.GetComponent<Text>();

        if (GetComponent<GetPodium>().scoreSet == true && scoreSet == false)
        {
            foreach (Score score in GetComponent<GetPodium>().best_scores)
            {
                score_text.text += score.Value + " : " + score.Winner + "\n" + "\n";
            }
            scoreSet = true;
        }

    }
}
