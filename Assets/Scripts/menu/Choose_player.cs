using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Choose_player : MonoBehaviour
{
    public string actual_choice = "Venom";
    public GameObject[] box_choices;
    public float box_size = 2.6f;
    public Player player;
    private user_management user_Management;
    private choose_player_management choose_player_management;
    private mqtt commands_manager;
    private bool can_move = true;
    public string key_right = "E";
    public string key_left = "W";
    public string key_top = "N";
    public string key_bottom = "S";
    private bool character_chosen;

    void Start()
    {
        character_chosen = false;
        choose_player_management = GameObject.FindGameObjectsWithTag("choose_player_manager")[0].GetComponent<choose_player_management>();
        user_Management = GameObject.FindGameObjectsWithTag("user_manager")[0].GetComponent<user_management>();
        commands_manager = GameObject.FindGameObjectsWithTag("commands_manager")[0].GetComponent<mqtt>();
        commands_manager.PlayersCommands[player.number - 1] = "";
        box_choices = GameObject.FindGameObjectsWithTag("box_choices");
        Move_to_character(actual_choice);
    }

    void Update()
    {
        Try_to_move(key_right, "right");
        Try_to_move(key_left, "left");
        Try_to_move(key_top, "top");
        Try_to_move(key_bottom, "bottom");

        if (commands_manager.PlayersCommands[player.number - 1] == "start" && character_chosen == false)
        {
            Validate_character(actual_choice);
        }
    }

    void Try_to_move(string command, string move)
    {
        if (can_move == true)
        {
            if (commands_manager.PlayersCommands[player.number - 1] == command)
            {
                Move(move);
                StartCoroutine(wait_to_move());
            }
        }
    }

    IEnumerator wait_to_move()
    {
        can_move = false;
        commands_manager.PlayersCommands[player.number - 1] = "";
        yield return new WaitForSeconds(0.5f);
        can_move = true;
    }

    void Validate_character(string character)
    {
        character_chosen = true;
        user_Management.Modify_player(player, character);
        choose_player_management.Validate_characters(player.number);
    }

    void Move(string shifting)
    {
        GameObject right_box = null;

        foreach (GameObject box in box_choices)
        {
            if (box.name != actual_choice && Vector3.Distance(box.transform.position, transform.position) <= box_size)
            {
                switch (shifting)
                {
                    case "left":
                        if (transform.position.x - box.transform.position.x > 0 && transform.position.y + box_size / 4 > box.transform.position.y && transform.position.y - box_size / 4 < box.transform.position.y)
                        {
                            right_box = box;
                        }
                        break;
                    case "right":
                        if (transform.position.x - box.transform.position.x < 0 && transform.position.y + box_size / 4 > box.transform.position.y && transform.position.y - box_size / 4 < box.transform.position.y)
                        {
                            right_box = box;
                        }
                        break;
                    case "top":
                        if (transform.position.y - box.transform.position.y < 0 && transform.position.x + box_size / 4 > box.transform.position.x && transform.position.x - box_size / 4 < box.transform.position.x)
                        {
                            right_box = box;
                        }
                        break;
                    case "bottom":
                        if (transform.position.y - box.transform.position.y > 0 && transform.position.x + box_size / 4 > box.transform.position.x && transform.position.x - box_size / 4 < box.transform.position.x)
                        {
                            right_box = box;
                        }
                        break;
                }
            }
        }

        if (right_box != null)
        {
            transform.position = right_box.transform.position;
            actual_choice = right_box.name;
        }
    }

    void Move_to_character(string character_name)
    {
        foreach (GameObject box in box_choices)
        {
            if (character_name == box.name)
            {
                transform.position = box.transform.position;
            }
        }
    }
}
