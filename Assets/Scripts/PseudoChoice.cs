using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PseudoChoice : Menu
{


    public List<Text> pseudo_text;
    public int alphabet_position = 0;

    public char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };


    public char[] pseudo = new char[4];
    private int pseudo_position = 0;
    public KeyCode move_left;
    public KeyCode move_right;
    public KeyCode move_up;
    public KeyCode move_down;
    public KeyCode validate;

    public GameObject alphabet_panel;

    private user_management user_management;
    public int user_number;

    void Start()
    {
        this.user_management = GameObject.FindGameObjectsWithTag("user_manager")[0].GetComponent<user_management>();
    }

    void Update()
    // Update is called once per frame void Update()
    {
        if (Input.GetKeyDown(move_right) && pseudo_position < pseudo.Length - 1)

        {
            alphabet_panel.transform.position = new Vector3(alphabet_panel.transform.position.x + 80, alphabet_panel.transform.position.y, alphabet_panel.transform.position.z);
            Update_pseudo();
            pseudo_position++;
        }




        if (Input.GetKeyDown(move_left) && pseudo_position > 0)
        {

            alphabet_panel.transform.position = new Vector3(alphabet_panel.transform.position.x - 80, alphabet_panel.transform.position.y, alphabet_panel.transform.position.z);
            Update_pseudo();
            pseudo_position--;
        }

        if (Input.GetKeyDown(move_down) && alphabet_position < 25)
        {
            alphabet_panel.transform.position = new Vector3(alphabet_panel.transform.position.x, alphabet_panel.transform.position.y + 20, alphabet_panel.transform.position.z);
            pseudo[pseudo_position] = alphabet[alphabet_position];

            alphabet_position += 1;

        }

        if (Input.GetKeyDown(move_up) && alphabet_position > 0)
        {
            alphabet_panel.transform.position = new Vector3(alphabet_panel.transform.position.x, alphabet_panel.transform.position.y - 20, alphabet_panel.transform.position.z);
            pseudo[pseudo_position] = alphabet[alphabet_position];

            alphabet_position -= 1;

        }

        if (Input.GetKeyDown(validate))
        {
            this.Add_pseudo_player(this.pseudo);
        }


    }

    void Update_pseudo()
    {
        pseudo[pseudo_position] = alphabet[alphabet_position];
        pseudo_text[pseudo_position].text = pseudo[pseudo_position].ToString();
    }





    void Add_pseudo_player(char[] new_pseudo)
    {
        this.user_management.players[this.user_number].pseudo = new string(new_pseudo);
    }

}