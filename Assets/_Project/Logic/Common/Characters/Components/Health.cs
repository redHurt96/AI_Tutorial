using UnityEngine;

namespace _Project.Logic.Common.Characters.Components
{
    public class Health : MonoBehaviour
    {
        [field:SerializeField] public float Value { get; private set; }

        public void Setup(float origin) => 
            Value = origin;

        public void Damage(float damage) => 
            Value = Mathf.Max(Value - damage, 0f);
    }
}