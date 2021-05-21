using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pseudo_manager : MonoBehaviour
{
    public GameObject[] pseudo_menus;
    private user_management user_manager;
    private int players_ready = 0;
    public string next_scene = "Choose_player_option";
    void Start()
    {
        user_manager = GameObject.FindGameObjectsWithTag("user_manager")[0].GetComponent<user_management>();
        foreach(GameObject pseudo_menu in pseudo_menus) {
            if(user_manager.players.Count >= pseudo_menu.GetComponent<PseudoChoice>().user_number) {
                pseudo_menu.SetActive(true);
            }
        }
    }

    public void Check_pseudo_chosen(){
        players_ready++;
        if(players_ready == user_manager.players.Count) {
            SceneManager.LoadScene(next_scene);
        }
    }
}
