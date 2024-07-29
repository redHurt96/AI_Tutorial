using System;
using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Common.Characters
{
    public class Attack : MonoBehaviour
    {
        public bool InCooldown => _currentCooldown > 0f;
        
        [SerializeField] private float _range;
        [SerializeField] private float _damage;
        [SerializeField] private float _cooldown;
        
        private float _currentCooldown;
        
        public bool CloseEnough(Character toTarget) => 
            Vector3.Distance(transform.position, toTarget.transform.position) < _range;

        public void Execute(Character withTarget)
        {
            withTarget.Health.SetDamage(_damage);
            _currentCooldown = _cooldown;
        }

        private void Update() => 
            _currentCooldown = Max(_currentCooldown - deltaTime, 0f);
    }
}