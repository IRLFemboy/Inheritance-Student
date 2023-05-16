using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            ActivatePickup();
            Destroy(gameObject);
        }
    }

    public virtual void ActivatePickup()
    {

    }
}
