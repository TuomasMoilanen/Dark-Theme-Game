using UnityEngine;
using UnityEngine.Events;

public class ObjectTrigger : MonoBehaviour

{
    [Header("Triggering tag")]
    [SerializeField, Tooltip("Define the tag that should be used to trigger.")] private string triggerTag; // The tagged object needs a collider

    [Header("Events")]
    [Tooltip("Triggers once, when object enters the collider.")] public UnityEvent triggerEnter;
    [Tooltip("Triggers once, when object leaves the collider.")] public UnityEvent triggerExit;
    [Tooltip("Triggers every update as the object is in the collider.")] public UnityEvent triggerStay;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggerTag))
        {
            triggerEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(triggerTag))
        {
            triggerExit?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(triggerTag))
        {
            triggerStay?.Invoke();
        }
    }
}