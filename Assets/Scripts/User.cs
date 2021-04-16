using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


public class User
{
    [JsonProperty("Id")]
    public int Id { get; set; }

    [JsonProperty("Pseudo")]
    public string Pseudo { get; set; }

    [JsonProperty("Score")]
    public int Score { get; set; }

    public User(int id, string pseudo, int score)
    {

        Id = id;
        Pseudo = pseudo;
        Score = score;
    }
}