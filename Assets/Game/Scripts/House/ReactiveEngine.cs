using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace House
{
    public class ReactiveEngine : MonoBehaviour
    {
        [SerializeField] private HouseController houseController;
        [SerializeField] private PushButton pushButton;
        [SerializeField] private ParticleSystem speedParticle;
        
        private bool _isActive;
        
        private void OnEnable()
        {
            pushButton.OnPressed += OnPressed;
        }
        
        private void OnDisable()
        {
            pushButton.OnPressed -= OnPressed;
        }

        private void OnPressed()
        {
            _isActive = !_isActive;
            houseController.ActivateReactiveSpeed(_isActive);
            if(_isActive)
                speedParticle.Play();
            else
                speedParticle.Stop();
        }
    }
}