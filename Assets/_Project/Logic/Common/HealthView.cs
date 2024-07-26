using UnityEngine;
using UnityEngine.UI;

namespace _Project.Common
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        private Character _character;

        public void Install(Character character)
        {
            _character = character;
            UpdateSlider();
            _character.OnHit += UpdateSlider;
        }

        private void OnDestroy() => 
            _character.OnHit -= UpdateSlider;

        private void UpdateSlider() => 
            _slider.normalizedValue = _character.Health / _character.MaxHealth;
    }
}