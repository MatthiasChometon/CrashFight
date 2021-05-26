using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choose_player_management : MonoBehaviour
{
    public List<GameObject> choose_boxes;
    private int players_number = 0;
    public string next_scene = "Battle";
    public GameObject[] box_choose;
    private List<int> characters_validated = new List<int>();
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

    public void Validate_characters(int player_number) {
        bool character_added = false;
        foreach(int character in characters_validated) {
            if(character == player_number) {
                character_added = true;
            }
        }

        if(character_added == false) {
            characters_validated.Add(player_number);
            if(characters_validated.Count == players_number) {
                SceneManager.LoadScene(next_scene);
            }
        }
    }

}
