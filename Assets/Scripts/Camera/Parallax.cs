using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;  //, Heigth // Defines the length and starting position of the spirte.

    [Header("References")]
    [Tooltip("Defines the camera of which the parllax effect follows.")]
    public Camera cam;

    [Header("Effects")]
    [Tooltip("Sets the value of the parallax effect from 0 - 1. 0 = Moves without parallax, 1 = moves with camera perfectly.")]
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;    // Finds sprites start position
        length = GetComponent<SpriteRenderer>().bounds.size.x;  // Finds sprites length 
    }

    void LateUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect)); 
        float dist = (cam.transform.position.x * parallaxEffect);   // Temporary value of how far have to gone from start position

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
