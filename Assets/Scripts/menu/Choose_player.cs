using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Choose_player : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode top;
    public KeyCode bottom;
    public KeyCode validate;
    public string actual_choice = "Venom";
    public GameObject[] box_choices;
    public float box_size = 2.6f;
    public Player player;
    private user_management user_Management;
    private choose_player_management choose_player_management;

    void Start()
    {
        choose_player_management = GameObject.FindGameObjectsWithTag("choose_player_manager")[0].GetComponent<choose_player_management>();
        user_Management = GameObject.FindGameObjectsWithTag("user_manager")[0].GetComponent<user_management>();
        box_choices = GameObject.FindGameObjectsWithTag("box_choices");
        Move_to_character(actual_choice);
    }

    void Update()
    {
        if (Input.GetKeyDown(left))
        {
            Move("left");
        }

        if (Input.GetKeyDown(right))
        {
            Move("right");
        }

        if (Input.GetKeyDown(top))
        {
            Move("top");
        }

        if (Input.GetKeyDown(bottom))
        {
            Move("bottom");
        }

        if (Input.GetKeyDown(validate))
        {
            Validate_character(actual_choice);
        }
    }

    void Validate_character(string character_chosen) {
        user_Management.Modify_player(player, character_chosen);
        choose_player_management.Check_character_chosen(true);
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
