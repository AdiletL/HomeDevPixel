using System;
using Resource;
using UnityEngine;

namespace Player
{
    public class PlayerItemController : MonoBehaviour
    {
        [SerializeField] private Transform handToCarry;
        [SerializeField] private float interactionRadius;
        
        private Item _item;
        
        private void Update()
        {
            CheckInput();
        }
        
        private void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.F)) ItemPick();
        }

        private void ItemPick()
        {
            if (_item != null)
            {
                _item.Deattach();
                _item = null;
                return;
            }
                
            var colliders = Physics.OverlapSphere(handToCarry.position, interactionRadius);
            for (int i = colliders.Length - 1; i >= 0; i--)
            {
                if (colliders[i].TryGetComponent(out Item item))
                {
                    _item = item;
                    item.Attach(handToCarry);
                    return;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(handToCarry.position, interactionRadius);
        }
    }
}