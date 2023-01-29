using UnityEngine;

public class CameraTriggers : MonoBehaviour
{
    #region Variables
    [Tooltip("Defines the camera that has desired script.")]
    public CameraScript cam;

    [SerializeField]
    [Tooltip("Defined desired offset for the trigger.")]
    private Vector2 triggeredOffset;

    #endregion Variables

    private void OnTriggerStay2D(Collider2D collision) // checks if trigger collider is hitting game object with tag of "Player"
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player in trigger zone!");
            cam.currentOffset = triggeredOffset;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision) // checks if game object left the trigger collider with the tag of "Player"
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player left the trigger zone!");
            cam.currentOffset = cam.defaultOffset;
        }
    }
}