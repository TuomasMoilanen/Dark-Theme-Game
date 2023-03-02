using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

public class cageCollider : MonoBehaviour
{
    #region Variables
    [Header("Switch")]
    [SerializeField, Tooltip("When enabled, object is detected as Enemy.")] private bool isEnemy;

    [Header("Sources")]
    [SerializeField, Tooltip("Defines mimics spawnable enemy game object.")] private GameObject mimic;
    [SerializeField, Tooltip("Defines mimic soul gameobject.")] private GameObject mimicSoul;
    [SerializeField, Tooltip("Defines the desired sound effect.")] private AudioSource mimicSFX;

    [SerializeField, Tooltip("Defines souls gameobject.")] private GameObject soul;
    [SerializeField, Tooltip("Defines the desired sound effect.")] private AudioSource soulSFX;
    public UIController controller;

    private int healthRestore = 1;
    public bool triggered = false;

    #endregion Varibles

    private void Awake()
    {
        if (isEnemy == true)
        {
            mimicSoul.gameObject.SetActive(true);

            soul.gameObject.SetActive(false);
        }
        if (isEnemy == false)
        {
            mimicSoul.gameObject.SetActive(false);

            soul.gameObject.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Debug.Log("Is the Cage an Enemy? " + isEnemy);
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>(); // finds the Player health script and nicknames it. On collision it searches for component "PlayerHealth" 
            
            // Cage is a friend! :)
            if (isEnemy == false)  // Searches the colliding collider if it is a player
            {
                triggered = true;

                // Spawn soul fly away
                //Animator animator = GetComponent<Animator>();

                // Make nice sound
                soulSFX.Play();

                // heals
                playerHealth.Heal(healthRestore); // adds health to "PlayerStats" scriptable object using "PlayerHealth" script with its "Heal" function
                controller.HeartsCollected();
            }

            // Cage is a enemy! >:(
            if (isEnemy == true) // Cage is a Enemy! >:(
            {
                triggered = true;
                // Constructor spawn enemy
                Invoke("OnSpawnMimic", 1);

                // Animator evil effect
                //Animator animator = GetComponent<Animator>();

                // Trigger evil sound
                mimicSFX.Play();
            }
            if(triggered == true)
            {
                // Destroy object
                Destroy(this, 1);
                Destroy(gameObject, 2);
                triggered = false;
            }
        }
    }

    private void OnSpawnMimic()
    {
        mimic.SetActive(true);
    }
}