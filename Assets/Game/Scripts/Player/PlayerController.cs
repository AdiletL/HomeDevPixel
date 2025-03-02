using System;
using System.Collections.Generic;
using House;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5;
        [SerializeField] private float rotationSpeed = 1000;
        [SerializeField] private float jumpPower = 3.5f;
        [SerializeField] private float gravity = Physics.gravity.y;
        
        [Space]
        [SerializeField] private Transform liftableObjectParent;
        
        private CharacterController characterController;
        private IInteractable currentInteractableObject;
        
        private Vector3 directionMovement;
        private bool isLadderCollision;

        private List<ILiftable> currentLiftableObjects = new();
        
        public ILiftable GetLiftableObjectInList()
        {
            return currentLiftableObjects.Count !=0 ? currentLiftableObjects[^1] : null;
        }
        public void SetLiftableObjectInList(ILiftable liftableObject)
        {
            if(liftableObject == null) return;
            liftableObject.SetParent(liftableObjectParent);
            liftableObject.Show();
            liftableObject.InActiveCollider();
        }

        public void AddLiftableInList(ILiftable liftable)
        {
            currentLiftableObjects.Add(liftable);
            Debug.Log("Add - Count resource: " + currentLiftableObjects.Count);
        }
        public void RemoveLiftableInList(ILiftable liftable)
        {
            currentLiftableObjects.Remove(liftable);
            Debug.Log("Remove - Count resource: " + currentLiftableObjects.Count);
        }
        
        public static PlayerController Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            CheckInput();
            ExecuteMovement();
            ExecuteRotate();
            ExecuteGravity();
        }

        private void CheckInput()
        {
            directionMovement.z = 0;
            
            if (Input.GetKeyDown(KeyCode.Space)) ExecuteJump();
            //if (Input.GetKeyDown(KeyCode.F)) ExecuteInteraction();
            
            if (Input.GetKey(KeyCode.A)) directionMovement.z = -1;
            if (Input.GetKey(KeyCode.D)) directionMovement.z = 1;

            if (isLadderCollision)
            {
                directionMovement.y = 0;
                if (Input.GetKey(KeyCode.W)) directionMovement.y = 1;
                if (Input.GetKey(KeyCode.S)) directionMovement.y = -1;
            }

            /*if (Input.GetKey(KeyCode.Q))
            {
                CameraController.Instance.ExecuteInHome();
            }
            if (Input.GetKey(KeyCode.E))
            {
                CameraController.Instance.ExecuteOutsideHome();
            }*/
        }

        private void ExecuteMovement()
        {
            characterController.Move(directionMovement * (movementSpeed * Time.deltaTime));
        }
        
        private void ExecuteRotate()
        {
            if(directionMovement.z == 0) return;
            Quaternion toRotation = Quaternion.LookRotation(directionMovement, Vector3.up);
            toRotation.x = 0;
            toRotation.z = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
        private void ExecuteJump()
        {
            if(characterController.isGrounded)
                directionMovement.y = jumpPower;
        }

        private void ExecuteInteraction()
        {
            if (currentInteractableObject is Boiler boiler)
            {
                /*if(currentLiftableObjects.Count == 0)
                    boiler.GiveResource(this);
                else
                    boiler.TakeResource(this);*/
                
                return;
            }
            else if (currentLiftableObjects.Count != 0)
            {
                currentLiftableObjects[^1].SetParent(null);
                currentLiftableObjects[^1].Show();
                currentLiftableObjects[^1].ActivateCollider();
                RemoveLiftableInList(currentLiftableObjects[^1]);
                return;
            }
            
            if(currentInteractableObject == null) return;

            if (currentInteractableObject is ILiftable liftable)
            {
                liftable.InActiveCollider();
                liftable.Show();
                liftable.SetParent(liftableObjectParent);
                liftable.SetLocalPosition(Vector3.zero);
                AddLiftableInList(liftable);
                currentInteractableObject = null;
            }
        }

        private void CheckResourceInRadius()
        {
            var colliders = Physics.OverlapSphere(transform.position, .5f);
            for (int i = colliders.Length - 1; i >= 0; i--)
            {
                if (colliders[i].TryGetComponent(out ILiftable liftable) &&
                    liftable is ResourceTrigger resourceTrigger)
                {
                    if (!currentLiftableObjects.Contains(resourceTrigger))
                    {
                        currentInteractableObject = resourceTrigger;
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            if(currentInteractableObject != null)
                Debug.Log(currentInteractableObject.GetType());
        }
        
        private void ExecuteGravity()
        {
            if(!characterController.isGrounded && !isLadderCollision)
                directionMovement.y += gravity * Time.deltaTime;
        }
        
        private void SetTargetGameObject(IInteractable target)
        {
            if (target is ILiftable liftable)
            {
                if(currentLiftableObjects.Contains(liftable))
                    return;
                
            }
            currentInteractableObject = target;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                SetTargetGameObject(interactable);
            }

            if (other.TryGetComponent(out Ladder ladder))
            {
                isLadderCollision = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                SetTargetGameObject(null);
                CheckResourceInRadius();
            }
            if (other.TryGetComponent(out Ladder ladder))
            {
                isLadderCollision = false;
            }
        }
    }
}