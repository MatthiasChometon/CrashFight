using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_ball_attack : Attack
{
    public override IEnumerator Init()
    {
        GetComponent<Move>().animator.SetBool("distance_attack", true);
        this.Can_attack = false;
        StartCoroutine(Authorize_attack(this.Couldown));
        yield return new WaitForSeconds(0.1f);
        float y;
        if (this.GetComponent<Move>().orientation == "left")
        {
            y = transform.position.x - 4f;
        }
        else
        {
            y = transform.position.x + 4f;
        }
        GameObject instance;
        instance = Instantiate(Object_attack, new Vector3(Mathf.RoundToInt(y),
            Mathf.RoundToInt(transform.position.y),
            Mathf.RoundToInt(transform.position.z)),
            transform.rotation);
        instance.GetComponent<Attack>().Damage = this.Damage;
        GetComponent<Warrior>().curent_attack = null;
        GetComponent<Move>().animator.SetBool("distance_attack", false);
    }
}
