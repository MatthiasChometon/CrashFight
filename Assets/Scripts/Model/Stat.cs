using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Stat
{
    [JsonProperty("life")]
    public int Life { get; set; }

    [JsonProperty("round")]
    public int Round { get; set; }

    public Stat(int life, int round)
    {
        this.Life = life;
        this.Round = round;
    }
}
