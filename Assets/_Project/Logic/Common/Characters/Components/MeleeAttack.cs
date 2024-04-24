using UnityEngine;

namespace _Project.Logic.Common.Characters.Components
{
    public class MeleeAttack : MonoBehaviour, IAttackComponent
    {
        public float Cooldown { get; private set; }
        public float Range { get; private set; }

        private float _damage;

        public void Setup(float damage, float cooldown, float range)
        {
            Cooldown = cooldown;
            Range = range;
            _damage = damage;
        }

        public void Execute(Unit target) =>
            target
                .GetComponent<Health>()
                .Damage(_damage);
    }
}