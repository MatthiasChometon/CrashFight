using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_options : MonoBehaviour
{
    public Text[] options;
    private int actual_option = 0;
    public string[] scenes;

    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Change_scene(actual_option);
        }
    }

    void Change_actual_option(int option)
    {
        foreach (Text op in options)
        {
            op.text = op.text.Replace("-", "");
        }
        options[option].text = "-" + options[option].text + "-";
        actual_option = option;
    }

    void Change_scene(int option)
    {
        if (option < scenes.Length && scenes[option] != "")
        {
            SceneManager.LoadScene(scenes[option]);
        }
    }
}
