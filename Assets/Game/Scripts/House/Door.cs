using Player;
using UnityEngine;

namespace House
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private bool isExit;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerController playerController)) return;
            
            if(!isExit)
                CameraController.Instance.ExecuteInHome();
            else
                CameraController.Instance.ExecuteOutsideHome();
        }
    }
}