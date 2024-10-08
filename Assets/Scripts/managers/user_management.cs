﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user_management : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    public List<Player> players = new List<Player>();
    public Vector3 coordonates_spawn;
    public bool rotate;
    public GameObject[] win_manager;
    public GameObject info_player;
    void Start()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("user_manager").Length == 2)
        {
            Destroy(GameObject.FindGameObjectsWithTag("user_manager")[1]);
        }
    }

    public void Modify_player(Player player_modify, string character_wanted)
    {
        players[players.IndexOf(players.Find(x => x.number == player_modify.number))].character_wanted = character_wanted;
    }

    public void Create_players()
    {
        win_manager = GameObject.FindGameObjectsWithTag("manager");

        win_manager[0].GetComponent<Win_manager>().players_number = players.Count;

        foreach (Player player in players)
        {
            foreach (GameObject character in characters)
            {
                if (character.GetComponent<Warrior>().name == player.character_wanted)
                {
                    GameObject instance;

                    switch (player.number)
                    {
                        case 1:
                            coordonates_spawn = new Vector3(-12f, -5.08f, -1);
                            break;
                        case 2:
                            coordonates_spawn = new Vector3(12f, -5.08f, -1);
                            break;
                        case 3:
                            coordonates_spawn = new Vector3(-6f, -5.08f, -1);
                            break;
                        case 4:
                            coordonates_spawn = new Vector3(6, -5.08f, -1);
                            break;
                    }

                    if (player.number % 2 == 0)
                    {
                        rotate = true;
                    }
                    else
                    {
                        rotate = false;
                    }

                    instance = Instantiate(character, coordonates_spawn,
                        transform.rotation);
                    if (rotate == true)
                    {
                        instance.transform.Rotate(0f, 180f, 0f);
                        instance.GetComponent<Move>().orientation = "left";
                    }
                    instance.GetComponent<Warrior>().number = player.number;
                    player.character = instance.GetComponent<Warrior>();
                }
            }
        }

        GameObject.FindGameObjectsWithTag("manager")[0].GetComponent<GetStat>().StartCoroutine("Get_stats_data");
        Initialize_hud();
    }

    public void Initialize_hud()
    {
        GameObject instance;
        var statBars = GameObject.FindGameObjectsWithTag("statbar");
        foreach (Player warrior in players)
        {
            foreach (GameObject statBar in statBars)
            {
                if (statBar.GetComponent<statBar>().number_player == warrior.number)
                {
                    statBar.GetComponent<statBar>().player = warrior;
                }
            }
            instance = Instantiate(info_player);
            instance.GetComponent<Info_player>().player = warrior;
        }
    }
}
