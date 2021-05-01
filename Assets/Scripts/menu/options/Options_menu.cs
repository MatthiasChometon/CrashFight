using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Options_menu : Menu
{
    public List<Slider> Sliders;
    void Update()
    {
        foreach (KeyCode validate_key in validate_keys)
        {
            if (Input.GetKey(validate_key))
            {
                Lauch_action(actual_option);
            }
        }
    }
    public override void Lauch_action(int option)
    {
        if (option < actions.Length && actions[option] != "")
        {
            //SceneManager.LoadScene(actions[option]);
        }
    }
}
