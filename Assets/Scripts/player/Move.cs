using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : control
{
    public float vitesse = 0.0001f;
    public float force = 0.012f;
    public float thrust = 40.0f;
    private bool init_stop_jump = false;
    public bool jump = true;
    private bool in_contact_ground = true;
    public int wait_jump = 10;
    public List<string> go_right = new List<string>() { "E", "NE", "SE" };
    public List<string> go_left = new List<string>() { "W", "NW", "SW" };
    public List<string> go_up = new List<string>() { "N", "NE", "NW" };
    public string orientation = "right";
    public Animator animator;

    void Update()
    {
        animator.SetBool("walk", false);
        can_move = false; 
        foreach (string key in go_right)
        {
            if (commands_manager.PlayersCommands[this.GetComponent<Warrior>().number - 1] == key)
            {
                animator.SetBool("walk", true);
                if (this.orientation == "left")
                {
                    transform.Rotate(0f, 180f, 0f);
                }
                right();
            }
        }

        foreach (string key in go_left)
        {
            if (commands_manager.PlayersCommands[this.GetComponent<Warrior>().number - 1] == key)
            {
                animator.SetBool("walk", true);
                if (this.orientation == "right")
                {
                    transform.Rotate(0f, 180f, 0f);
                }
                left();
            }
        }
        foreach (string key in go_up)
        {
            if (commands_manager.PlayersCommands[this.GetComponent<Warrior>().number - 1] == key && jump)
            {
                if (!init_stop_jump)
                {
                    StartCoroutine("Stop_jumping");
                }

                init_stop_jump = true;
                Jump();
            }
        }
    }

    void left()
    {
        this.orientation = "left";
        transform.Translate(vitesse, 0, 0);
    }

    void right()
    {
        this.orientation = "right";
        transform.Translate(vitesse, 0, 0);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
    }

    private IEnumerator Stop_jumping()
    {
        for (int i = 0; i < wait_jump; i++)
        {
            yield return null;
        }
        if (!in_contact_ground)
        {
            jump = false;
            init_stop_jump = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            in_contact_ground = true;
            init_stop_jump = false;
            jump = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        in_contact_ground = false;
    }
}
