using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Menu : MonoBehaviour
{
    public Text[] options;
    protected int actual_option = 0;
    public string[] actions;
    public List<KeyCode> validate_keys;
    public List<KeyCode> next_keys;
    public List<KeyCode> last_keys;

    void Update()
    {
        foreach (KeyCode next_key in next_keys)
        {
            if (Input.GetKeyDown(next_key))
            {
                if (actual_option > 0)
                {
                    Change_actual_option(actual_option - 1);
                }
            }
        }

        foreach (KeyCode last_key in last_keys)
        {
            if (Input.GetKeyDown(last_key))
            {
                if (actual_option < options.Length - 1)
                {
                    Change_actual_option(actual_option + 1);
                }
            }
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

    public virtual void Lauch_action(int option)
    {

    }
}
