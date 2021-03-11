using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middle_cut : Attack
{
    public override IEnumerator Init()
    {
        GetComponent<Move>().animator.SetBool("middle_cut", true);
        if (this.Object_in_contact != null && this.Object_in_contact.tag == "Player")
        {
            this.Can_attack = false;
            StartCoroutine(Authorize_attack(this.Couldown));
        }
        yield return new WaitForSeconds(0.5f);
        GetComponent<Warrior>().curent_attack = null;
        GetComponent<Move>().animator.SetBool("middle_cut", false);
    }
}
