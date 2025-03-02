using System;
using UnityEngine;

namespace Player
{
    
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class ResourceController : MonoBehaviour, ILiftable
    {
        [SerializeField] private ResourceTrigger resourceTrigger;
        [SerializeField] public GameObject visual;

        private SphereCollider sphereCollider;
        private Rigidbody rb;
        
        private void Start()
        {
            sphereCollider = GetComponent<SphereCollider>();
            rb = GetComponent<Rigidbody>();
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetLocalPosition(Vector3 localPosition)
        {
            transform.localPosition = localPosition;
        }
        
        public void Show() => visual.SetActive(true);
        public void Hide() => visual.SetActive(false);
        
        public void ActivateCollider()
        { 
            sphereCollider.enabled = true;
            rb.useGravity = true;
            resourceTrigger.baseCollider.enabled = true;
        }

        public void InActiveCollider()
        {
            sphereCollider.enabled = false;
            rb.useGravity = false;
        }

        public void Interact(PlayerController playerController)
        {
            
        }
    }
}