using System;
using Resource;
using UnityEngine;

namespace House
{
    public class Workshop : MonoBehaviour
    {
        [SerializeField] private PushButton pushButton;
        [SerializeField] private Spanner spanner;
        [SerializeField] private Transform spawnPoint;
        private Spanner _spawnedSpanner;
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
            if(_spawnedSpanner!=null)
                Destroy(_spawnedSpanner.gameObject);
            
            _spawnedSpanner=Instantiate(spanner, spawnPoint.position, Quaternion.identity);
        }
    }
}