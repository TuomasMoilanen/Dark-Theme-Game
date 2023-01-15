using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireProjectile : MonoBehaviour
{
    public PlayerProjectile playerProjectilePrefab;
    public Transform launchOffset;
    private bool projectileCooldown;
    void Update()
    {   // Fire the projectile with a cooldown
        if (Input.GetButtonDown("Fire1") && projectileCooldown == false)
        {
            // Spawn the projectile prefab to the launchOffset
            Instantiate(playerProjectilePrefab, launchOffset.position, transform.rotation);

            // Start a delay before another one can be fired
            projectileCooldown = true;
            StartCoroutine(Cooldown());
        }
    }

    // Delay coroutine
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1);
        projectileCooldown = false;
    }
}
