using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Puzzle {

[RequireComponent(typeof(BoxCollider))]
public class WaitForObjectTrigger : MonoBehaviour
{
    public string objectTag = "Resource";
    public UnityEvent onObjectEnter;
    public UnityEvent onObjectExit;

    public BoxCollider boxCollider;

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerController player))
        {
            onObjectEnter.Invoke();
            return;
        }

        if(other.CompareTag(objectTag))
        {
            onObjectEnter.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out PlayerController player))
        {
            onObjectExit.Invoke();
            return;
        }

        if(other.CompareTag(objectTag))
        {
            onObjectExit.Invoke();
        }
    }
}

}