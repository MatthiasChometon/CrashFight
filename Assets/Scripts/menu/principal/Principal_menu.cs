using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Principal_menu : Menu
{
    public List<KeyCode> validate_keys;
    void Update()
    {
        foreach (KeyCode validate_key in validate_keys)
        {
            if (Input.GetKeyDown(validate_key))
            {
                Lauch_action(actual_option);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (actual_option > 0)
            {
                Change_actual_option(actual_option - 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (actual_option < options.Length - 1)
            {
                Change_actual_option(actual_option + 1);
            }
        }
    }
    public override void Lauch_action(int option)
    {
        if (option < actions.Length && actions[option] != "")
        {
            SceneManager.LoadScene(actions[option]);
        }
    }
}
