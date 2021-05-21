using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return_menu : Menu
{
    void Update()
    {
        if (commands_manager.PlayersCommands[0] == "red")
        {
            Lauch_action();
        }
    }

    public override void Lauch_action() {
        SceneManager.LoadScene(actual_option);
    }
}
