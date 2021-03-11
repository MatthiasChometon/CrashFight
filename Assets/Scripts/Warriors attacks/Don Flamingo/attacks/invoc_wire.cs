using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invoc_wire : Attack
{
    public GameObject[] Players;
    public GameObject Player_most_closer;
    public override IEnumerator Init()
    {
        if (GetComponent<Move>().jump == true)
        {
            GetComponent<Move>().animator.SetBool("invoc_wire", true);
            this.Can_attack = false;
            StartCoroutine(Authorize_attack(this.Couldown));
            yield return new WaitForSeconds(0.1f);
            Players = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < Players.Length; i++)
            {
                if (Vector3.Distance(transform.position,
                         Players[i].transform.position) != 0)
                {
                    if (Player_most_closer == null)
                    {
                        Player_most_closer = Players[i];
                    }
                    if (Vector3.Distance(transform.position,
                             Players[i].transform.position) < Vector3.Distance(transform.position,
                             Player_most_closer.transform.position))
                    {
                        Player_most_closer = Players[i];
                    }
                }
            }
            GameObject instance;
            instance = Instantiate(Object_attack, new Vector3(Mathf.RoundToInt(Player_most_closer.transform.position.x),
                -6.393f,
                Mathf.RoundToInt(transform.position.z)),
                transform.rotation);
            instance.GetComponent<Attack>().Damage = this.Damage;
            GetComponent<Warrior>().curent_attack = null;
            GetComponent<Move>().animator.SetBool("invoc_wire", false);
        }
    }
}
