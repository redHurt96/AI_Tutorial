using System;
using UnityEngine;
using static UnityEngine.Mathf;

namespace _Project.Common.Characters
{
    public class Health : MonoBehaviour
    {
        public event Action OnHit;
        public event Action OnDie;
        
        [field:SerializeField] public float Value { get; private set; }
        [field:SerializeField] public float MaxValue { get; private set; }

        public void SetDamage(float amount)
        {
            Value = Max(Value - amount, 0f);
            
            OnHit?.Invoke();

            if (Approximately(Value, 0f)) 
                OnDie?.Invoke();
        }
    }
}