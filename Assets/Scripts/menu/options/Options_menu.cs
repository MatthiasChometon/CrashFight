using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_menu : Menu
{
    public Slider[] Sliders;
    public string return_menu;
    private bool wait_change_value = true;

    void Update()
    {

        if (wait_change_value)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                StartCoroutine(Lauch_action(actual_option, "+"));
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                StartCoroutine(Lauch_action(actual_option, "-"));
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (actual_option == options.Length - 1)
            {
                IEnumerator coroutine = GetComponent<PostStat>().Upload(return_menu);
                GetComponent<PostStat>().StartCoroutine(coroutine);
            }
        }

    }
    public IEnumerator Lauch_action(int option, string operation)
    {
        wait_change_value = false;
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
        yield return new WaitForSeconds(Sliders[option].maxValue*Sliders[option].maxValue/1000000000);
        wait_change_value = true;
    }
}
