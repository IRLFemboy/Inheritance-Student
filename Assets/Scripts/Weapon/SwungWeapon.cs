using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeapon : Weapon
{
    public float swingSpeed;
    public float swingDeg;

    public override void Attack()
    {
        if(canAttack)
        {
            //Start attakc cooldown
            Invoke("AttackReset", 60f / attackRate);
            //Rotate to starting position
            transform.localEulerAngles = new Vector3(0, 0, -swingDeg);
            //Turn on weapon
            EnableWeapon();
            //Swing down
            StartCoroutine(Swing());
        }

    }


    //Write swinging coroutine
    IEnumerator Swing()
    {
        float degrees = 0f;
        while(degrees < swingDeg * 2)
        {
            transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            degrees += swingSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
            Debug.Log(degrees);
        }

        DisableWeapon();
    }
}
