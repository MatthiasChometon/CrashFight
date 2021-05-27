using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PseudoChoice : Menu
{
    public List<Text> pseudo_text;
    public int alphabet_position = 0;
    public char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    public char[] pseudo = new char[4];
    private int pseudo_position = 0;
    public GameObject alphabet_panel;
    private user_management user_management;
    public int user_number;
    public float alphabet_translation;
    public float pseudo_translation;
    private pseudo_manager pseudo_manager;
    void Start()
    {
        character_chosen = false;
        pseudo_manager = GameObject.FindGameObjectsWithTag("pseudo_manager")[0].GetComponent<pseudo_manager>();
        user_management = GameObject.FindGameObjectsWithTag("user_manager")[0].GetComponent<user_management>();
        commands_manager = GameObject.FindGameObjectsWithTag("commands_manager")[0].GetComponent<mqtt>();
    }

    void Update()
    {
        if (can_move == true)
        {
            if (commands_manager.PlayersCommands[user_number - 1] == "E" && pseudo_position < pseudo.Length - 1)
            {
                Go_right();
            }

            if (commands_manager.PlayersCommands[user_number - 1] == "W" && pseudo_position > 0)
            {
                Go_left();
            }

            if (commands_manager.PlayersCommands[user_number - 1] == "S" && alphabet_position < 25)
            {
                Go_up();
            }

            if (commands_manager.PlayersCommands[user_number - 1] == "N" && alphabet_position > 0)
            {
                Go_down();
            }

            if (commands_manager.PlayersCommands[user_number - 1] == "start" && character_chosen == false)
            {
                character_chosen = true;
                Update_pseudo();
                this.Add_pseudo_player(this.pseudo);
            }
        }
    }
    void Update_pseudo()
    {
        pseudo[pseudo_position] = alphabet[alphabet_position];
        pseudo_text[pseudo_position].text = pseudo[pseudo_position].ToString();
    }

    void Go_right()
    {
        StartCoroutine(wait_to_move(0.3f, 0));
        alphabet_panel.transform.position = new Vector3(alphabet_panel.transform.position.x + pseudo_translation, alphabet_panel.transform.position.y, alphabet_panel.transform.position.z);
        Update_pseudo();
        pseudo_position++;
    }

    void Go_left()
    {
        StartCoroutine(wait_to_move(0.3f, 0));
        alphabet_panel.transform.position = new Vector3(alphabet_panel.transform.position.x - pseudo_translation, alphabet_panel.transform.position.y, alphabet_panel.transform.position.z);
        Update_pseudo();
        pseudo_position--;
    }

    void Go_up()
    {
        StartCoroutine(wait_to_move(0.3f, 0));
        alphabet_panel.transform.position = new Vector3(alphabet_panel.transform.position.x, alphabet_panel.transform.position.y + alphabet_translation, alphabet_panel.transform.position.z);
        pseudo[pseudo_position] = alphabet[alphabet_position];
        alphabet_position += 1;
    }

    void Go_down()
    {
        StartCoroutine(wait_to_move(0.3f, 0));
        alphabet_panel.transform.position = new Vector3(alphabet_panel.transform.position.x, alphabet_panel.transform.position.y - alphabet_translation, alphabet_panel.transform.position.z);
        pseudo[pseudo_position] = alphabet[alphabet_position];
        alphabet_position -= 1;
    }
    void Add_pseudo_player(char[] new_pseudo)
    {
        StartCoroutine(wait_to_move(0.3f, 0));
        user_management.players[this.user_number - 1].pseudo = new string(new_pseudo);
        pseudo_manager.Check_pseudo_chosen();
    }

}