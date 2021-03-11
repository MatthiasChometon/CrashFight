using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int number;
    public string pseudo;
    public string character_wanted;
    public int rounds_win = 0;
    public Warrior character;
    public Player(int number, string character_wanted, string pseudo)
    {
        this.number = number;
        this.character_wanted = character_wanted;
        this.pseudo = pseudo;
    }

}
