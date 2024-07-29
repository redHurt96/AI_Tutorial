using _Project.Common.Characters;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Common.Ui
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Slider _slider;
        
        private void Start()
        {
            _slider.maxValue = _health.MaxValue;
            UpdateSlider();
            _health.OnHit += UpdateSlider;
        }

        private void OnDestroy() => 
            _health.OnHit += UpdateSlider;

        private void UpdateSlider() => 
            _slider.value = _health.Value;
    }
}