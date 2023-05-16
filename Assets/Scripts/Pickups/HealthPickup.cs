using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public int heal;

    public override void ActivatePickup()
    {
        player.health += heal;
        if(player.health > player.maxHealth)
        {
            player.health = player.maxHealth;
        }
    }
}
