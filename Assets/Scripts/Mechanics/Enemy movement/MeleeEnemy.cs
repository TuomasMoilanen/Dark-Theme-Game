using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    #region Variables
    public EnemyStats stats;  // Takes variables from scriptable object
    
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField]
    [Tooltip("Defines the box collider of this object to use in raycast.")]
    private BoxCollider2D boxCollider;

    [SerializeField]
    [Tooltip("Defines detection distance variable")]
    private float colliderDistance;

    [SerializeField]
    [Tooltip("Defines player layer to be used in raycast")]
    private LayerMask playerLayer;
    //private Animator anim;    // ----------------------------------I  Place holder  I---------------------------------- \\ > How to tie it together if needed https://youtu.be/d002CljR-KU?t=1070 
    //private int playerHealth; // ----------------------------------I  Place holder  I---------------------------------- \\

    #endregion

    /*private void Awake()
    {
        //anim = GetComponent<Animator>();  // ----------------------------------I  Place holder  I---------------------------------- \\
    }*/

    private void Update()
    {
        cooldownTimer += Time.deltaTime; // Sets cooldown timer on Delta time

        if (PlayerInSight())
        {
            // Attack only when player is in sight
            if (cooldownTimer >= stats.attackCooldown)
            {
                cooldownTimer= 0;
                //anim.SetTrigger(""); // ----------------------------------I  Place holder  I---------------------------------- \\
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = // Sets raycast detection to find player in melee range
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * stats.range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * stats.range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        //if (hit.collider != null)
        //{
        //    playerHealth = stats.health; // ----------------------------------I  Place holder  I---------------------------------- \\
        //}
        
        return hit.collider != null; // Returns true if raycast found player
    }

    private void OnDrawGizmos() // Draws raycast on unity gizmos
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * stats.range * transform.localScale.x * colliderDistance,
            new Vector3 (boxCollider.bounds.size.x * stats.range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    //private void DamagePlayer() // ----------------------------------I  Place holder  I---------------------------------- \\
    //{
    //    // Damage player health
    //}
}
