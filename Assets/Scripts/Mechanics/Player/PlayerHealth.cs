using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerStats stats;
    public GameOver gameOver;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        stats.health -= damage;
        if (stats.health <= 0)
        {
            animator.ResetTrigger("jumping");
            animator.ResetTrigger("falling");
            animator.ResetTrigger("walking");
            animator.SetBool("isDead", true);
            gameOver.EndGame();
        }
    }

    public void Heal(int healthRestore)
    {
        if (stats.health < 3) // If player health is less than 3 calls "healthRestore function in CageCollider script 
        {
            stats.health += healthRestore;
        }
    }
}
