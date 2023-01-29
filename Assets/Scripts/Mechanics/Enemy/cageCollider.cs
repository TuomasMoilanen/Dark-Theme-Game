using Unity.Mathematics;
using UnityEngine;

public class cageCollider : MonoBehaviour
{
    #region Variables
    [Header("Switch")]
    [SerializeField]
    [Tooltip("When enabled, object is detected as Enemy.")]
    private bool isEnemy;

    [Header("Sources")]
    [SerializeField]
    [Tooltip("Defines mimics spawnable enemy game object.")]
    private GameObject mimic;

    [SerializeField]
    [Tooltip("Copy this game objects X and Y values to spawn mimic on itself.")]
    private Vector2 spawnPosition;

    [SerializeField]
    [Tooltip("Defines the desired sound effect.")]
    private AudioSource audioSource;

    private bool triggered = false;

    #endregion Varibles

    private void Awake()
    {
        spawnPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Debug.Log("Is the Cage an Enemy? " + isEnemy);

            // Cage is a friend! :)
            if (isEnemy == false)  // Searches the colliding collider if it is a player
            {
                // Spawn soul fly away
                //Animator animator = GetComponent<Animator>();

                // Make nice sound
                //audioSource.enabled = true;

                // add max health?

                triggered = true;
            }

            // Cage is a enemy! >:(
            if (isEnemy == true) // Cage is a Enemy! >:(
            {
                // Constructor spawn enemy
                OnSpawnMimic();

                // Animator evil effect
                //Animator animator = GetComponent<Animator>();

                // Trigger evil sound
                //audioSource.enabled = true;

                triggered = true;
            }
            if(triggered == true)
            {
                // Destroy object
                Destroy(this);
                Destroy(gameObject, 2);
                triggered = false;
            }
        }
    }

    private void OnSpawnMimic()
    {
            Instantiate(mimic, spawnPosition, Quaternion.identity);
    }
}