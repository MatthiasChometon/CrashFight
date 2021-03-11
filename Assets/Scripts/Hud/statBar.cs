using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statBar : MonoBehaviour
{
    public int number_player;
    public Slider sliderHealth;
    public GameObject search_bar;
    public Player player;
    public GameObject win_round_point;
    public int number_round_win_display = 0;
    public int position_x_shift = -3;

    void Update()
    {
        if (player != null)
        {
            DisplayStat();
        } else {
            gameObject.SetActive(false);
        }
    }

    private void DisplayStat()
    {
        sliderHealth.value = player.character.Life;

        if (number_round_win_display < player.rounds_win)
        {
            GameObject instance;
            instance = Instantiate(win_round_point, new Vector3(transform.position.x + position_x_shift, transform.position.y - 1, transform.position.z),
                transform.rotation);
            position_x_shift += 1;
            number_round_win_display += 1;

            if(player.rounds_win == GameObject.FindGameObjectsWithTag("manager")[0].GetComponent<Win_manager>().round_for_win) {

            }
        }
    }

}