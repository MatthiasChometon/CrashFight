using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_ground : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D collision)
    {
        var Object_in_contact = collision.gameObject;
        if (Object_in_contact && Object_in_contact.tag == "Player")
        {
            Destroy(Object_in_contact);
        }

    }
}
