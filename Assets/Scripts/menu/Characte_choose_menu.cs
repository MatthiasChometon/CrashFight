using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characte_choose_menu : Menu
{
    public List<GameObject> characters;
    public Vector3 actual_box_position = new Vector3(0, 0, 0);
    public GameObject box;
    void Start()
    {
        Generate_characters_box();
    }

    void Update()
    {

    }

    void Generate_characters_box()
    {
        GameObject instance;
        GameObject box_character_child;
        foreach (GameObject character in characters)
        {
            instance = Instantiate(box, actual_box_position,
            transform.rotation);
            box_character_child = instance.GetComponent<Add_character_choice>().character;
            box_character_child.GetComponent<SpriteRenderer>().sprite = character.GetComponent<SpriteRenderer>().sprite;
            actual_box_position = new Vector3(actual_box_position.x + box_character_child.GetComponent<Transform>().localScale.x, actual_box_position.y, actual_box_position.z);
        }

    }
}
