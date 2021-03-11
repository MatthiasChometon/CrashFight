using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_attack : Attack
{
    public override IEnumerator Init()
    {
        this.Can_attack = false;
        GetComponent<Move>().animator.SetBool("middle_attack", true);
        StartCoroutine(Authorize_attack(this.Couldown));
        yield return new WaitForSeconds(0.05f);
        GameObject instance;
        instance = Instantiate(Object_attack, new Vector3(Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.y + 8),
            Mathf.RoundToInt(transform.position.z)),
            transform.rotation);
        instance.GetComponent<Attack>().Damage = this.Damage;
        GetComponent<Warrior>().curent_attack = null;
        GetComponent<Move>().animator.SetBool("middle_attack", false);
    }
}
