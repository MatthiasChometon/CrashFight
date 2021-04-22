using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact_attack : Attack
{
    public override IEnumerator Init()
    {
        GetComponent<Move>().animator.SetBool(this.animation_name, true);
        if (this.Object_in_contact != null && this.Object_in_contact.tag == "Player")
        {
            this.Can_attack = false;
            StartCoroutine(Authorize_attack(this.Couldown));
        }
        yield return new WaitForSeconds(this.Couldown);
        GetComponent<Warrior>().curent_attack = null;
        GetComponent<Move>().animator.SetBool(this.animation_name, false);
    }
}
