using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Move and destroy the projectile
    [SerializeField] private float speed = 1000f;
    void Update()
    {
        // Move projectile, speed control doesn't work
        transform.position += transform.right * speed * Time.deltaTime;
    }

    //Destroy the projectile after a collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
