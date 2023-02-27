using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyStats stats;
    private Animator anim;
    public PointsCalculator pointsCalculator;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        stats.health = stats.startingHealth;
    }
    public void TakeDamage(int damage)
    {
        stats.health -= damage;
        if (stats.health <= 0)
        {
            anim.SetBool("isDead", true);
            Destroy(gameObject);
            pointsCalculator.enemiesKilled++;
        }
    }
}
