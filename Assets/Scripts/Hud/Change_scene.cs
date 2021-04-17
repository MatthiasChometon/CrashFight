using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_scene : MonoBehaviour
{
    public string LevelToLoad;
    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
