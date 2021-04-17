using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_menu : Menu
{
    public Slider[] Sliders;
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Lauch_action(actual_option, "+");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Lauch_action(actual_option, "-");
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
    public void Lauch_action(int option, string operation)
    {
        if (option < Sliders.Length && Sliders[option] != null)
        {

            if (operation == "-")
            {
                Sliders[option].value -= 1;
            }

            if (operation == "+")
            {
                Sliders[option].value += 1;
            }
        }
    }
}
