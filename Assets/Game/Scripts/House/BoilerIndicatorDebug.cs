using UnityEngine;
using UnityEngine.UI;

namespace House
{
    public class BoilerIndicatorDebug : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private Boiler boiler;

        private void Update()
        {
            slider.value = boiler.Progress;
        }
    }
}