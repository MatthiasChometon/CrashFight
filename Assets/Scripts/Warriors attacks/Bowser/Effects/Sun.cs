using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : Attack
{
    float angle = 0;
    float radius = 8;
    float x;
    float y;

    public float time_alive = 2f;

    void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void Start()
    {
        Destroy(gameObject, time_alive);
        Speed = (2 * Mathf.PI) / Speed;
    }

    void Update()
    {
        angle -= Speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
        x = Mathf.Cos(angle) * radius;
        y = Mathf.Sin(angle) * radius;
        transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * Speed);
    }
}