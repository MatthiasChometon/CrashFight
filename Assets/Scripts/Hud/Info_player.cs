using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info_player : MonoBehaviour
{
    public Player player = null;
    public Text number_player;
    public GameObject indicator;
    void Start()
    {
        transform.SetParent(GameObject.FindGameObjectsWithTag("hud")[0].transform);
        transform.localScale = new Vector3(1, 1, 1);
    }
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.character.transform.position.x, player.character.transform.position.y + 3, 200);
            number_player.text = "P" + player.character.number.ToString();
            Color info_player_color = Color.white;

            switch (player.character.number)
            {
                case 1:
                    ColorUtility.TryParseHtmlString("#03C2FC", out info_player_color);
                    break;
                case 2:
                    info_player_color = Color.red;
                    break;
                case 3:
                    info_player_color = Color.yellow;
                    break;
                case 4:
                    ColorUtility.TryParseHtmlString("#03FC67", out info_player_color);
                    break;
            }
            indicator.GetComponent<SpriteRenderer>().color = info_player_color;
            number_player.color = info_player_color;
        }
    }
}
