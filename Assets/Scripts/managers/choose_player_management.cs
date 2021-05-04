using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choose_player_management : MonoBehaviour
{
    public List<GameObject> choose_boxes;
    private int players_number = 0;
    public string next_scene = "Battle";
    void Start()
    {
        GameObject user_manager = GameObject.FindGameObjectsWithTag("user_manager")[0];
        foreach (Player player in user_manager.GetComponent<user_management>().players)
        {
            choose_boxes[player.number - 1].GetComponent<Choose_player>().player = player;
            choose_boxes[player.number - 1].SetActive(true);
            players_number++;
        }
    }

    public void Check_character_chosen(bool character_choosen)
    {
        if (character_choosen)
        {
            players_number--;
        }
        else
        {
            players_number++;
        }
        if (players_number == 0)
        {
            SceneManager.LoadScene(next_scene);
        }
    }

}
