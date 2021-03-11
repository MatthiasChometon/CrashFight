using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invoked_wire : Attack
{
    public float time_alive = 0.2f;
    void OnCollisionStay2D(Collision2D collision)
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    void Start()
    {
        Destroy(gameObject, time_alive);
    }
}
