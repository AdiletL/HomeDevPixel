using System;
using System.Collections.Generic;
using Player;
using Resource;
using UnityEngine;
using UnityEngine.Serialization;

namespace House
{

    public class Boiler : MonoBehaviour
    {
        [SerializeField] private float maxEnergy;
        [SerializeField] private PushButton upPushButton;
        [SerializeField] private PushButton downPushButton;
        [SerializeField] private Transform boilerCoalTransform;
        [SerializeField] private ParticleSystem burningParticleSystem;
        [SerializeField] private HouseController houseController;

        private readonly List<Coal> _coalResources = new(); 
        private float _energy;
        public bool HasEnergy => _energy > 0;
        public float Progress => _energy / maxEnergy;
        
        public void FixedUpdate()
        {
            _energy = Mathf.Max(_energy - Time.fixedDeltaTime, 0);
            
            if(!HasEnergy)
                burningParticleSystem.Stop();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Coal resource)) return;
            _coalResources.Add(resource);
            resource.gameObject.SetActive(false);
            _energy += resource.Energy;
            burningParticleSystem.Play();
            houseController.Move();

            if (resource.TryGetComponent(out Item item)) 
                item.Attach(boilerCoalTransform);
        }
        
        private void OnEnable()
        {
            upPushButton.OnPressed += OnUpPressed;
            downPushButton.OnPressed += OnDownPressed;
        }
        
        private void OnDisable()
        {
            upPushButton.OnPressed -= OnUpPressed;
            downPushButton.OnPressed -= OnDownPressed;
        }
       
        private void OnUpPressed()
        {
            
        }
        
        private void OnDownPressed()
        {
            
        }

        private void OnPressed()
        {
            if (_coalResources.Count == 0) return;

            var coal = _coalResources[^1];
            _coalResources.Remove(coal);
            coal.gameObject.SetActive(true);
            
            if(coal.TryGetComponent(out Item item))
                item.Deattach();
        }
    }
}