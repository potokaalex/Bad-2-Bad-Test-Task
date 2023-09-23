using UnityEngine;
using UnityEngine.UI;

namespace GameCore.CodeBase.Gameplay.Health.UI
{
    public class HealthSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void Construct(int maxValue, int currentValue)
        {
            _slider.maxValue = maxValue;
            _slider.value = currentValue;
        }

        public void SetHealth(int value) => _slider.value = value;
    }
}