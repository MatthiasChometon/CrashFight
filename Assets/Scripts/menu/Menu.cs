using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Menu : control
{
    public Text[] options;
    protected int actual_option = 0;
    public string[] actions;
    void Start()
    {
        if (options.Length != 0)
        {
            options[actual_option].text = "-" + options[actual_option].text + "-";
        }
        character_chosen = false;
        commands_manager = GameObject.FindGameObjectsWithTag("commands_manager")[0].GetComponent<mqtt>();
    }

    public void Change_actual_option(int option)
    {
        foreach (Text op in options)
        {
            op.text = op.text.Replace("-", "");
        }
        options[option].text = "-" + options[option].text + "-";
        actual_option = option;
    }

    public virtual void Lauch_action()
    {
        
    }
}
