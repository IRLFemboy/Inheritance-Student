using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : Pickup
{
    public override void ActivatePickup()
    {
        Enemy[] enemiesArray = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemiesArray)
        {
            Destroy(enemy.gameObject);
        }
    }
}
