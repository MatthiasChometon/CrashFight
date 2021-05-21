using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_menu : Menu
{
    public Slider[] Sliders;
    public string return_menu;
    private bool wait_change_value = true;
    public float change_value_speed = 0.1f;

    void Update()
    {
        if (can_move == true)
        {
            if (wait_change_value)
            {
                if (commands_manager.PlayersCommands[0] == "E")
                {
                    StartCoroutine(Lauch_action(actual_option, "+"));
                }

                if (commands_manager.PlayersCommands[0] == "W")
                {
                    StartCoroutine(Lauch_action(actual_option, "-"));
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
                    StartCoroutine(wait_to_move(0.3f, 0));
                }
            }

            if (commands_manager.PlayersCommands[0] == "start" || commands_manager.PlayersCommands[0] == "yellow")
            {
                if (actual_option == options.Length - 1)
                {
                    IEnumerator coroutine = GetComponent<PostStat>().Upload(return_menu);
                    GetComponent<PostStat>().StartCoroutine(coroutine);
                }
            }
        }

    }
    public IEnumerator Lauch_action(int option, string operation)
    {
        wait_change_value = false;
        if (Sliders[option] != null)
        {
            if (option < Sliders.Length)
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
            yield return new WaitForSeconds(1 / Sliders[option].maxValue);
        }
        wait_change_value = true;
    }
}
