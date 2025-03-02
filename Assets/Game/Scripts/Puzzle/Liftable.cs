using System.Collections;
using UnityEngine;

namespace Puzzle {

[RequireComponent(typeof(Rigidbody))]
public class Liftable : MonoBehaviour, IInteractble
{
    public Rigidbody rb;
    public Collider col;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    public void Interact()
    {
        
    }

    public Transform GetTransform() => transform;
}

}
