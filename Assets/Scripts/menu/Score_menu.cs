using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score_menu : Menu
{
    public string return_menu = "Base_menu";
    void Update()
    {
        if (commands_manager.PlayersCommands[0] == "yellow" || commands_manager.PlayersCommands[0] == "start")
        {
            Return_to_menu();
        }
    }

    void Return_to_menu() {
        SceneManager.LoadScene(return_menu);
    }
}
