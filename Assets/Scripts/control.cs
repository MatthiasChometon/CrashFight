using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    protected bool can_move = true;
    protected bool character_chosen;
    protected mqtt commands_manager;

    void Start()
    {
        character_chosen = false;
        commands_manager = GameObject.FindGameObjectsWithTag("commands_manager")[0].GetComponent<mqtt>();
    }

    protected IEnumerator wait_to_move(float time_to_wait, int player)
    {
        can_move = false;
        commands_manager.PlayersCommands[player] = "";
        yield return new WaitForSeconds(time_to_wait);
        can_move = true;
    }
}
