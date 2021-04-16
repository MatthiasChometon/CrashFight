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
    private Player winner_player = null;
    void Start()
    {
        int i = 0;
        manager = GameObject.FindGameObjectsWithTag("manager")[0];
        foreach (Player player in manager.GetComponent<user_management>().players)
        {
            if (player.number == manager.GetComponent<Win_manager>().winner.number)
            {
                win_text.text = "- " + player.pseudo + " -";
                win_character_panel.GetComponent<Image>().sprite = player.character.GetComponent<SpriteRenderer>().sprite;
            }
            
            score_text.text += player.rounds_win;

            if(manager.GetComponent<user_management>().players.Count == player[0]) {
                score_text.text += " / ";
            }
            
            i++;
        }
        StartCoroutine(AnimatePanels());
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
