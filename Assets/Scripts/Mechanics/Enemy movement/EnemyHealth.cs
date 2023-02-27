using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyStats stats;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        stats.health = stats.startingHealth;
    }
    public void TakeDamage(int damage)
    {
        stats.health -= damage;
    }
}
