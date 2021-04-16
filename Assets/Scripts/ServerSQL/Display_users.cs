using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_users : MonoBehaviour
{

    private bool userSet = false;
    private List<User> best_players;
    public GameObject score;

    void Start()
    {
        GetComponent<GetPodium>().StartCoroutine("GetPodiumData");
    }

    void Update()
    {
        Text score_text = score.GetComponent<Text>();
        score_text.alignment = TextAnchor.MiddleCenter;


        if (GetComponent<GetPodium>().usersGet == true && userSet == false)
        {
            foreach (User user in GetComponent<GetPodium>().users)
           {
            score_text.text += user.Pseudo;
            score_text.text += "     ";
            score_text.text += user.Score.ToString();
            score_text.text += "\n";

            }
            userSet = true;
        }

    }
}
