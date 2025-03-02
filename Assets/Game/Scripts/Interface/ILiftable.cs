using UnityEngine;

public interface ILiftable : IInteractable
{
    public void SetParent(Transform parent);

    public void Show();
    public void Hide();
    
    public void ActivateCollider();
    public void InActiveCollider();

    public void SetPosition(Vector3 position);

    public void SetLocalPosition(Vector3 localPosition);
}