using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class principal_menu_manager : MonoBehaviour
{
    public bool menu_display = false;
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
