using RH_Modules.Utilities.Attributes;
using UnityEngine;
using static UnityEngine.Vector3;

namespace _Project.Logic.Common.Characters.Components
{
    public class SelectedUnit : MonoBehaviour
    {
        public bool HasTarget => _target != null;
        public Vector3 TargetPosition => _target.transform.position;
        public bool CloseEnoughToAttack => HasTarget 
                                           && Distance(transform.position, TargetPosition) <= _attackRange;

        [SerializeField, ReadOnly] private Unit _target;
        
        private float _attackRange;
        private float _damage;

        public void Setup(float attackRange, float damage)
        {
            _damage = damage;
            _attackRange = attackRange;
        }

        public void SetTarget(Unit value)
        {
            _target = value;
            value.Destroyed += Clear;
        }

        private void Clear(Unit target)
        {
            target.Destroyed += Clear;
            _target = null;
        }

        public void Attack() => 
            _target
                .GetComponent<Health>()
                .Damage(_damage);
    }
}