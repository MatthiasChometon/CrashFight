using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_manager : MonoBehaviour
{
    public int players_number = 0;
    public Warrior winner = null;
    public GameObject round_win_panel;
    public GameObject game_win_panel;
    public int round_for_win = 3;
    public string redirect_scene = "Base_menu";
    private user_management user_management;

    void Start() {
        user_management = GameObject.FindGameObjectsWithTag("user_manager")[0].GetComponent<user_management>();
    }

    public void Test_victory(Warrior player)
    {
        players_number -= 1;
        if (players_number == 0)
        {
            round_win_panel.SetActive(true);
            round_win_panel.GetComponent<display_round_win>().Display_winner_round();
        }
        if (players_number == 1)
        {
            foreach (GameObject warrior in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (warrior.GetComponent<Warrior>() && warrior.GetComponent<Warrior>().Life > 0)
                {
                    winner = warrior.GetComponent<Warrior>();
                    Add_point();
                    if (Check_game_victory())
                    {
                        game_win_panel.SetActive(true);
                        Score score = game_win_panel.GetComponent<display_final_winner>().Display_winner_game();
                        StartCoroutine(GetComponent<PostPodium>().UploadPodium(score, redirect_scene));
                    }
                    else
                    {
                        round_win_panel.SetActive(true);
                        round_win_panel.GetComponent<display_round_win>().Display_winner_round();
                    }
                }
            }
        }
    }

    public void Start_round()
    {
        Destroy_game();
        user_management.Create_players();
        round_win_panel.SetActive(false);
        game_win_panel.SetActive(false);
    }

    void Add_point()
    {
        foreach (Player player in user_management.players)
        {
            if (player.number == this.GetComponent<Win_manager>().winner.GetComponent<Warrior>().number)
            {
                player.rounds_win += 1;
            }
        }
    }

    void Destroy_game()
    {
        foreach (GameObject warrior in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(warrior);
        }
        foreach (GameObject attack in GameObject.FindGameObjectsWithTag("attack"))
        {
            Destroy(attack);
        }
    }


    bool Check_game_victory()
    {
        foreach (Player player in user_management.players)
        {
            if (player.rounds_win == round_for_win)
            {
                return true;
            }
        }
        return false;
    }
}
