using UnityEngine;

public class CameraScript : MonoBehaviour
{
    #region Variables
    [Header("Player location")]
    [Tooltip("Defined player game object")]
    public GameObject player;

    [SerializeField] 
    [Tooltip("Time delay when camera moves")]
    private float timeOffset;

    [SerializeField]
    [Tooltip("Defined offset from player")]
    private Vector2 posOffset;

    [SerializeField]
    [Tooltip("Disable camera boundries")]
    private bool debug;
    #endregion

    #region Camera boundaries
    [Header("Camera's Boundries")]

    [SerializeField]
    [Tooltip("Camera's left side limit")]
    private float leftLimit;

    [SerializeField]
    [Tooltip("Camera's right side limit")]
    private float rightLimit;

    [SerializeField]
    [Tooltip("Camera's top side limit")]
    private float topLimit;

    [SerializeField]
    [Tooltip("Camera's bottom side limit")]
    private float bottomLimit;

    #endregion

    void Update()
    {
        Vector3 startPos = transform.position;  // Cam Start pos
        Vector3 endPos = player.transform.position; // Players current pos
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        #region Camera Smoothing
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);   // Lerp Camera smoothing

        // Secondary camera movement code --------------------------------------

        // SmoothDamp Camera smoothing, Needs velocity attribute
        //transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);
        #endregion

        if (debug == false)
        {
            transform.position = new Vector3    // Clamping camera boundries
                (
                    Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                    Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                    transform.position.z
                );
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;    // Drawn box color around our camera boundary on unity Gizmos
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));   // Top boundary line        
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));   // Right boundary line        
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit)); // Bottom boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit)); // Left boundary line
    }
}