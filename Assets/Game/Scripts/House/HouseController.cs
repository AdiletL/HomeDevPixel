using System;
using Sirenix.OdinInspector;
using Player;
using UnityEngine;

namespace House
{
    public class HouseController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float acceleration=0;
        [SerializeField] private float reactiveSpeed;
        
        [SerializeField] private Boiler boiler;
        private Rigidbody _rb;
        private Vector3 _moveDirection=Vector3.forward;
        private PlayerController _playerController;

        private bool _useReactiveEngine;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void Move()
        {
            var velocity = _moveDirection * (moveSpeed * (_useReactiveEngine ? reactiveSpeed : 1));
            _rb.linearVelocity = velocity;
            _playerController.GetComponent<CharacterController>().Move(velocity*Time.fixedDeltaTime);
        }
        
        public void ActivateReactiveSpeed(bool active)
        {
            _useReactiveEngine = active;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                _playerController = playerController;
                playerController.transform.SetParent(transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                _playerController = null;
                playerController.transform.SetParent(null);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            print(other.transform.name);
        }
    }
}
