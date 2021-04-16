using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Stat
{
    [JsonProperty("life")]
    public int Life { get; set; }

    [JsonProperty("attack")]
    public int Attack { get; set; }

    public Stat(int life, int attack)
    {
        this.Life = life;
        this.Attack = attack;
    }
}
