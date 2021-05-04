using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_manager : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectsWithTag("user_manager")[0].GetComponent<user_management>().Create_players();
    }
}
