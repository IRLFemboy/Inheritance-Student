using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D bulletRB;
    Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<Gun>();
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.AddRelativeForce(Vector2.right * gun.bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.GetComponent<Enemy>().TakeDamage(gun.bulletDamage);
        }
    }
}
