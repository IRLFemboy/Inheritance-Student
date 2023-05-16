using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : Pickup
{
    public float speedBonus;

    public override void ActivatePickup()
    {
        StartCoroutine(IncreaseSpeed());

    }

    IEnumerator IncreaseSpeed()
    {
        player.moveSpeed += speedBonus;
        Debug.Log("Speed increased!");
        yield return new WaitForSeconds(3);
        player.moveSpeed = player.baseSpeed;
        Debug.Log("Speed decreased!");
    }
}
