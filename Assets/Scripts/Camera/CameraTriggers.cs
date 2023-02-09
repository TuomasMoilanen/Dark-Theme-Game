using UnityEngine;

public class CameraTriggers : MonoBehaviour
{
    #region Variables
    [Tooltip("Defines the main camera.")]
    public Camera mainCamera;

    [Tooltip("Defines the camera that has desired script.")]
    public CameraScript cam;

    [SerializeField]
    [Tooltip("Defines the triggered camera Size. Default Value = 5.")]
    private float zoomSize;
    private float defaultZoomSize = 5;

    [SerializeField]
    private float speed;

    [SerializeField]
    [Tooltip("Defined desired offset for the trigger.")]
    private Vector2 triggeredOffset;

    [SerializeField]
    private bool zoomActive;

    #endregion Variables

    private void LateUpdate()
    {
        if (zoomActive)
        {
            mainCamera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomSize, speed);
        }
        else
        {
            mainCamera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, defaultZoomSize, speed);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) // checks if trigger collider is hitting game object with tag of "Player"
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player in trigger zone!");
            cam.currentOffset = triggeredOffset;
            zoomActive = true;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision) // checks if game object left the trigger collider with the tag of "Player"
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player left the trigger zone!");
            cam.currentOffset = cam.defaultOffset;
            zoomActive = false;
        }
    }
}