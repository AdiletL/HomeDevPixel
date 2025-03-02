using System;
using Player;
using UnityEngine;

public class ResourceTrigger : MonoBehaviour, ILiftable
{
    [field: SerializeField] public ResourceController ResourceController { get; private set; }

    public Collider baseCollider;

    private void Start()
    {
        baseCollider = GetComponent<Collider>();
    }

    public void Interact(PlayerController playerController)
    {
        throw new System.NotImplementedException();
    }

    public void SetParent(Transform parent) => ResourceController.SetParent(parent);

    public void Show() => ResourceController.Show();

    public void Hide() => ResourceController.Hide();

    public void ActivateCollider() => ResourceController.ActivateCollider();

    public void InActiveCollider()
    {
        ResourceController.InActiveCollider();
        baseCollider.enabled = false;
    }

    public void SetPosition(Vector3 position) => ResourceController.SetPosition(position);

    public void SetLocalPosition(Vector3 localPosition) => ResourceController.SetLocalPosition(localPosition);
}
