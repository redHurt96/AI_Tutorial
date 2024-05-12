using UnityEngine;

namespace _Project.Logic.Common.Characters.Components
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        
        private float _damage;
        private Team _team;

        public void Launch(Vector3 direction, float damage, Team team)
        {
            _team = team;
            _damage = damage;
            transform.forward = direction;
            _rigidbody.velocity = direction * _speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Unit unit)
                && unit.Team != _team)
            {
                unit
                    .GetComponent<Health>()
                    .Damage(_damage);
                Destroy(gameObject);
            }
        }
    }
}