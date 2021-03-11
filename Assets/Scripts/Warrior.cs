using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Warrior : MonoBehaviour
{
    public int Life = 100;
    public int number;
    public GameObject Object_in_contact = null;
    public List<Attack> Attacks;
    public int Damage;
    public Attack curent_attack;
    public GameObject manager;
    void Start()
    {
        manager = GameObject.FindGameObjectsWithTag("manager")[0];
        Attacks = GetComponents<Attack>().ToList();
    }
    void Update()
    {
        foreach (Attack attack in Attacks)
        {
            if (attack.Can_attack == true)
            {
                if (Input.GetKeyDown(attack.Key))
                {
                    this.curent_attack = attack;
                    StartCoroutine(attack.Init());
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        this.Object_in_contact = collision.gameObject;
        if (this.Object_in_contact.tag == "attack")
        {
            Take_damage(this.Object_in_contact.GetComponent<Attack>().Damage, false);
        }

        if (this.Object_in_contact && this.Object_in_contact.tag == "Player")
        {
            Take_damage(this.Object_in_contact.GetComponent<Warrior>().Damage);
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        this.Object_in_contact = null;
    }

    public void Take_damage(int damage, bool near_attack = true)
    {
        if (this.Object_in_contact.GetComponent<Warrior>() && this.Object_in_contact.GetComponent<Warrior>().curent_attack != null && near_attack)
        {
            damage = this.Object_in_contact.GetComponent<Warrior>().curent_attack.Damage;
        }
        StartCoroutine(Take_damage_animation(damage, this.Object_in_contact, near_attack));
        this.Life -= damage;
        if (this.Life <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
            Destroy(gameObject);
            manager.GetComponent<Win_manager>().Test_victory(this.GetComponent<Warrior>());
        }
    }
    public IEnumerator Take_damage_animation(int damage, GameObject player_attack, bool distance_attack)
    {
        if (damage > 0)
        {
            GetComponent<Move>().animator.SetBool("hurt", true);
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(0.15f);
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        yield return new WaitForSeconds(0.1f);
        GetComponent<Move>().animator.SetBool("hurt", false);
    }

}
