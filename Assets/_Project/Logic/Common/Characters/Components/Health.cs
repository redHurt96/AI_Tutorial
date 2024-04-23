using RH_Modules.Utilities.Attributes;
using UnityEngine;
using static UnityEngine.Mathf;

namespace _Project.Logic.Common.Characters.Components
{
    public class Health : MonoBehaviour
    {
        [field:SerializeField, ReadOnly] public float Value { get; private set; }

        public void Setup(float origin) => 
            Value = origin;

        public void Damage(float damage) => 
            Value = Max(Value - damage, 0f);
    }
}