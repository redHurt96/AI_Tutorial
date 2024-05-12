using UnityEngine;

namespace _Project.Logic.Common.Characters.Components
{
    public class RangeAttack : MonoBehaviour, IAttackComponent
    {
        public float Cooldown { get; private set; }
        public float Range { get; private set; }

        [SerializeField] private Projectile _prefab;
        [SerializeField] private Transform _origin;
        
        private float _damage;
        private Team _team;

        public void Setup(float damage, float cooldown, float range, Team team)
        {
            _team = team;
            _damage = damage;
            Cooldown = cooldown;
            Range = range;
        }

        public void Execute(Unit target)
        {
            Vector3 rawDirection = target.transform.position - _origin.position;
            Instantiate(_prefab, _origin.position, _origin.rotation)
                .Launch(rawDirection.normalized, _damage, _team);
        }
    }
}