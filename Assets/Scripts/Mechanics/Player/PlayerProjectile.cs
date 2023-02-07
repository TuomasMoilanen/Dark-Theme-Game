using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Move and destroy the projectile
    [SerializeField] private float speed = 5f;
    void Update()
    {
        // Move projectile, speed control doesn't work
        transform.position += transform.right * speed * Time.deltaTime;
    }

    //Destroy the projectile after a collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Destroy(gameObject);
    }
}
