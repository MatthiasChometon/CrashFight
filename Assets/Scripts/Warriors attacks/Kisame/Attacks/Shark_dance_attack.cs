using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_dance_attack : Attack
{
    public override IEnumerator Init()
    {
        this.Can_attack = false;
        GetComponent<Move>().animator.SetBool("shark_dance_attack", true);
        StartCoroutine(Authorize_attack(this.Couldown));
        yield return new WaitForSeconds(0.25f);
        GameObject instance;
        instance = Instantiate(Object_attack, new Vector3(Mathf.RoundToInt(transform.position.x)-0.23f,
            Mathf.RoundToInt(transform.position.y - 2f),
            Mathf.RoundToInt(transform.position.z)),
            transform.rotation);
        instance = Instantiate(Object_attack, new Vector3(Mathf.RoundToInt(transform.position.x)-0.23f,
            Mathf.RoundToInt(transform.position.y - 2f),
            Mathf.RoundToInt(transform.position.z)),
            transform.rotation);
        instance.transform.Rotate(180.0f, 0.0f, 180.0f);
        instance.GetComponent<Attack>().Damage = this.Damage;
        GetComponent<Warrior>().curent_attack = null;
        GetComponent<Move>().animator.SetBool("shark_dance_attack", false);
    }
}
