using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int Damage = 0;
    public float Speed = 4;
    public GameObject Object_attack;
    public float Couldown = 0.1f;
    public KeyCode Key;
    public bool Can_attack = true;
    public GameObject Object_in_contact = null;
    public string animation_name;

    public virtual IEnumerator Init()
    {
        yield return null;
    }

    public IEnumerator Authorize_attack(float time_to_wait)
    {
        yield return new WaitForSeconds(time_to_wait);
        this.Can_attack = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.Object_in_contact = collision.gameObject;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        this.Object_in_contact = null;
    }
    

}
