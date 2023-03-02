using UnityEngine;

public class SoulCollect : MonoBehaviour
{
    [SerializeField, Tooltip("Is asigned automatically.")] private Transform player;
    [SerializeField, Tooltip("Sets the soul models offset when picked up")] private Vector3 offset;
    [SerializeField] private ObjectTrigger trigger;


    [Tooltip("Defines if soul has been collected")] public bool collectedSoul = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SoulGot()
    {
        collectedSoul= true;
    }

    private void Update()
    {
        if (collectedSoul == true)
        {
           transform.position = player.position + offset;
        }
    }
}