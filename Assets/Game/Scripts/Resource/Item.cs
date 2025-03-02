using UnityEngine;

namespace Resource
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private Collider physicalCollider;
        
        public void Deattach()
        {
            transform.SetParent(null);
            rigidBody.isKinematic = false;
            physicalCollider.enabled = true;
        }

        public void Attach(Transform parent)
        {
            transform.SetParent(parent);
            rigidBody.isKinematic = true;
            transform.localPosition = Vector3.zero;
            physicalCollider.enabled = false;
        }
    }
}