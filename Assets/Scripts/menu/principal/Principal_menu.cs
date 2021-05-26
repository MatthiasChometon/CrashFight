using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Principal_menu : Menu
{
    public string[] validate_keys;
    void Update()
    {
        if (can_move == true)
        {
            foreach (string validate_key in validate_keys)
            {
                if (commands_manager.PlayersCommands[0] == validate_key)
                {
                    Lauch_action();
                    StartCoroutine(wait_to_move(0.3f, 0));
                }
            }

            if (commands_manager.PlayersCommands[0] == "N")
            {
                if (actual_option > 0)
                {
                    Change_actual_option(actual_option - 1);
                    StartCoroutine(wait_to_move(0.3f, 0));
                }
            }

            if (commands_manager.PlayersCommands[0] == "S")
            {
                if (actual_option < options.Length - 1)
                {
                    Change_actual_option(actual_option + 1);
                    StartCoroutine(wait_to_move(0.6f, 0));
                }
            }
        }

    }

    public override void Lauch_action()
    {
        if (actual_option < actions.Length && actions[actual_option] != "")
        {
            Debug.Log(actions[actual_option]);
            SceneManager.LoadScene(actions[actual_option]);
        }
    }
}
