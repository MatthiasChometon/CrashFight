﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_invoked : Attack
{
    void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        StartCoroutine("Shark_move");
    }

    IEnumerator Shark_move()
    {
        yield return new WaitForSeconds(0.6f);
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
    }
}
