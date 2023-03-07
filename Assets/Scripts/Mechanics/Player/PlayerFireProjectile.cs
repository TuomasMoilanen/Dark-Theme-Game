using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireProjectile : MonoBehaviour
{
    public PlayerProjectile playerProjectilePrefab;
    public Transform launchOffset;
    private bool projectileCooldown;
    [SerializeField] private AudioSource SFX;

    void Update()
    {   // Fire the projectile with a cooldown
        if (Input.GetButtonDown("Fire1") && projectileCooldown == false)
        {
            // Spawn the projectile prefab to the launchOffset
            Instantiate(playerProjectilePrefab, launchOffset.position, transform.rotation);

            // Start a delay before another one can be fired
            projectileCooldown = true;
            StartCoroutine(Cooldown());
            SFX.Play();
        }
    }

    // Delay coroutine
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.7f);
        projectileCooldown = false;
    }
}