using System;
using UnityEngine;

namespace Resource
{
    public class Coal : MonoBehaviour
    {
        [SerializeField] private float energyVolume;

        public event Action OnBurned;
        public float Energy => energyVolume;
        public bool IsEmpty => energyVolume <= 0;
        
        public void ReduceEnergy(float value)
        {
            if (IsEmpty) return;
            energyVolume -= value;
            if(IsEmpty)
                OnBurned?.Invoke();
        }
    }
}