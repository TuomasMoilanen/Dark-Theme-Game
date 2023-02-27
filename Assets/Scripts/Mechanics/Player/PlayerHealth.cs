using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerStats stats;
    public PlayerMovement mov;

    private Transform spawnPoint;
    private Transform playerPos;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    public void TakeDamage(int damage)
    {
        stats.health -= damage;
        if (stats.health <= 0)
        {
            animator.SetBool("isDead", true);
            Invoke("EndGame", 1);
            mov.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    public void EndGame()
    {
        playerPos.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        mov.GetComponent<PlayerMovement>().enabled = true;
        animator.SetBool("isDead", false);

        stats.health = 3;
    }

    public void Heal(int healthRestore)
    {
        if (stats.health < 3) // If player health is less than 3 calls "healthRestore function in CageCollider script 
        {
            stats.health += healthRestore;
        }
    }
}
