using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_invok : Attack
{
    public override IEnumerator Init()
    {
        this.Can_attack = false;
        GetComponent<Move>().animator.SetBool("shark_invok_attack", true);
        StartCoroutine(Authorize_attack(this.Couldown));
        yield return new WaitForSeconds(0.1f);
        float x;
        if (GetComponent<Move>().orientation == "left")
        {
            x = transform.position.x - 3;
        }
        else
        {
            x = transform.position.x + 3;
        }
        GameObject instance;
        instance = Instantiate(Object_attack, new Vector3(x,
            Mathf.RoundToInt(transform.position.y) - 0.5f,
            Mathf.RoundToInt(transform.position.z)),
            transform.rotation);
        instance.GetComponent<Attack>().Damage = this.Damage;
        GetComponent<Warrior>().curent_attack = null;
        GetComponent<Move>().animator.SetBool("shark_invok_attack", false);
    }
}
