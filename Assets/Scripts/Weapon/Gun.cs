using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : Weapon
{
    public GameObject boolet;
    public Transform muzzle;
    public int baseAmmoCount;
    public int ammoCount;
    public int bulletDamage;
    public float bulletSpeed;

    public TextMeshProUGUI ammoText;

    void Start()
    {
        ammoText = GameObject.Find("ammoText").GetComponent<TextMeshProUGUI>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        muzzle = GameObject.Find("Muzzle").transform;
        ammoCount = baseAmmoCount;
        ammoText.text = "Rounds: " + ammoCount + "/" + baseAmmoCount;
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
        Instantiate(boolet, muzzle.position, muzzle.rotation);
        canAttack = false;
        ammoCount--;
        ammoText.text = "Rounds: " + ammoCount + "/" + baseAmmoCount;
    }

    IEnumerator Reload()
    {
        if(ammoCount < baseAmmoCount)
        {
            ammoText.text = "Reloading...";
            canAttack = false;
            yield return new WaitForSeconds(.5f);
            ammoCount = baseAmmoCount;
            ammoText.text = "Rounds: " + ammoCount + "/" + baseAmmoCount;
            yield return new WaitForSeconds(.5f);
            canAttack = true;
        }
    }
}
