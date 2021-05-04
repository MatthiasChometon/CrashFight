using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_final_winner : MonoBehaviour
{
    public GameObject manager;
    public Text win_text = null;
    public GameObject win_character_panel;
    public GameObject left_panel;
    public GameObject right_panel;
    public Text score_text = null;
    private user_management user_management;

    public Score Display_winner_game()
    {
        user_management = GameObject.FindGameObjectsWithTag("user_manager")[0].GetComponent<user_management>();
        int i = 0;
        manager = GameObject.FindGameObjectsWithTag("manager")[0];
        var pseudo = "";
        foreach (Player player in user_management.players)
        {
            if (player.number == manager.GetComponent<Win_manager>().winner.number)
            {
                pseudo = player.pseudo;
                win_text.text = "- " + pseudo + " -";
                win_character_panel.GetComponent<Image>().sprite = player.character.GetComponent<SpriteRenderer>().sprite;
            }

            score_text.text += player.rounds_win;

            if (user_management.players.Count - 1 != i)
            {
                score_text.text += " / ";
            }

            i++;
        }
        StartCoroutine(AnimatePanels());
        return new Score(score_text.text, pseudo);
    }

    IEnumerator AnimatePanels()
    {
        for (int i = 0; i < 10000; i++)
        {
            left_panel.transform.Translate(Vector3.right * Time.deltaTime * 50);
            right_panel.transform.Translate(Vector3.left * Time.deltaTime * 50);
            if (right_panel.transform.position.x <= 9f)
            {
                break;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
}
