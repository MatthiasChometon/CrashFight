using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


public class Score
{
    [JsonProperty("Id")]
    public int Id { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("winner")]
    public string Winner { get; set; }

    public Score(string value, string winner)
    {
        Value = value;
        Winner = winner;
    }
}