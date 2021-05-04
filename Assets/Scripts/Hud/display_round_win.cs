using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_round_win : MonoBehaviour
{
    public GameObject manager;
    public Text winner_text = null;
    public Text win_text = null;
    public GameObject left_panel;
    public GameObject right_panel;
    private user_management user_management;

    public void Display_winner_round()
    {
        user_management = GameObject.FindGameObjectsWithTag("user_manager")[0].GetComponent<user_management>();
        manager = GameObject.FindGameObjectsWithTag("manager")[0];
        foreach (Player player in user_management.players)
        {
            if (player.number == manager.GetComponent<Win_manager>().winner.number)
            {
                winner_text.text = "- " + player.pseudo + " -";
                win_text.text = "Win the round";
            }
        }

        if (win_text.text == "")
        {
            win_text.text = "nobody win";
        }
        StartCoroutine(AnimatePanels());
    }


    IEnumerator AnimatePanels()
    {
        for (int i = 0; i < 10000; i++)
        {
            left_panel.transform.Translate(Vector3.right * Time.deltaTime * 30);
            left_panel.transform.Translate(Vector3.down * Time.deltaTime * 30);
            right_panel.transform.Translate(Vector3.down * Time.deltaTime * 30);
            right_panel.transform.Translate(Vector3.right * Time.deltaTime * 30);
            if (left_panel.transform.position.y <= 0.15f)
            {
                break;
            }
            yield return new WaitForSeconds(0.002f);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 10000; i++)
        {
            left_panel.transform.Translate(Vector3.right * Time.deltaTime * -30);
            left_panel.transform.Translate(Vector3.down * Time.deltaTime * -30);
            right_panel.transform.Translate(Vector3.down * Time.deltaTime * -30);
            right_panel.transform.Translate(Vector3.right * Time.deltaTime * -30);
            winner_text.text = "";
            win_text.text = "";
            if (left_panel.transform.position.y >= 7.29f)
            {
                break;
            }
            yield return new WaitForSeconds(0.002f);
        }
        manager.GetComponent<Win_manager>().Start_round();
    }
}
