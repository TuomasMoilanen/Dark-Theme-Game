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
            animator.SetBool("isDead", true);
            gameOver.EndGame();
        }

    }
}
