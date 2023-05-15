using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public GameObject boolet;
    public Transform muzzle;
    public int baseAmmoCount;
    public int ammoCount;

    void Start()
    {
        muzzle = GameObject.Find("Muzzle").transform;
        ammoCount = baseAmmoCount;
        DisableWeapon();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    public override void Attack()
    {
        if(canAttack && ammoCount > 0)
        {
            EnableWeapon();
            boxCollider.enabled = true;
            Shoot();
            Invoke("DisableWeapon", attackDuration);
            Invoke("AttackReset", 60f / attackRate);
        }

        if(ammoCount <= 0)
        {
            canAttack = false;
            StartCoroutine(Reload());
        }
    }

    public void Shoot()
    {
        Instantiate(boolet, muzzle.position, transform.rotation);
        canAttack = false;
        ammoCount--;
    }

    IEnumerator Reload()
    {
        if(ammoCount < baseAmmoCount)
        {
            canAttack = false;
            yield return new WaitForSeconds(.5f);
            ammoCount = baseAmmoCount;
            yield return new WaitForSeconds(.5f);
            canAttack = true;
        }
    }
}
