using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyStats stats;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        stats.health -= damage;
        if (stats.health <= 0)
        {
            anim.SetTrigger("enemyDie");
            Destroy(gameObject);
        }

    }
}
