using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate_menu : MonoBehaviour
{
    public GameObject menu_subtitles;
    public GameObject menu_press_key;
    private bool menu_display = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !menu_display)
        {
            Display_menu();
            menu_display = true;
        }
    }


    void Display_menu()
    {
        StartCoroutine(Animate_menu());
        StartCoroutine(Animate_subtitles());
    }

    IEnumerator Animate_menu()
    {
        menu_press_key.SetActive(false);
        for (int i = 0; i < 10000; i++)
        {
            if (transform.position.y >= 1.4f)
            {
                break;
            }
            transform.Translate(Vector3.up * Time.deltaTime * 30);
            yield return new WaitForSeconds(0.003f);
        }
    }

    IEnumerator Animate_subtitles()
    {
        menu_subtitles.SetActive(true);
        for (int i = 0; i < 10000; i++)
        {
            menu_subtitles.transform.Translate(Vector3.up * Time.deltaTime * 30);
            if (menu_subtitles.transform.position.y >= 1.4f)
            {
                break;
            }
            yield return new WaitForSeconds(0.003f);
        }
    }

}
