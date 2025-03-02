using System;
using Player;
using UnityEngine;

namespace House
{
    public class PushButton : MonoBehaviour
    {
        public event Action OnPressed;
        [SerializeField] private Animator animator;
        private static readonly int Pressing = Animator.StringToHash("Pressing");

        private void OnTriggerEnter(Collider other)
        {
            print(other.gameObject.name);
            if (!other.TryGetComponent(out PlayerController playerController)) return;
            OnPressed?.Invoke();
            animator.SetBool(Pressing,true);
        }

        private void OnTriggerExit(Collider other)
        {
            print(other.gameObject.name);
            if (!other.TryGetComponent(out PlayerController playerController)) return;
            animator.SetBool(Pressing,false);
        }
    }
}