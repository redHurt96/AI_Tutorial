using System;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Mathf;
using static UnityEngine.Time;
using static UnityEngine.Vector3;

namespace _Project.Common
{
    public class Character
    {
        private const float UPDATE_PATH_DELAY = .2f;
        private const float ATTACK_DISTANCE = 1.2f;
        private const float ATTACK_COOLDOWN = 1f;
        private const float DAMAGE = 1f;
        
        public event Action OnHit;
        public event Action<Character> OnDie;

        public bool HasEnemy => _enemy != null;
        public Vector3 Position => _transform.position;
        public bool InMoveCooldown => _moveCooldown > 0f;
        public bool InAttackCooldown => _attackCooldown > 0f;
        public bool CloseToEnemy => Distance(Position, _enemy.Position) < ATTACK_DISTANCE;
        public bool IsEnemyAlive => HasEnemy && _enemy.Health > 0f;

        public float Health { get; private set; }
        
        public readonly int Team;
        public readonly float MaxHealth;

        private float _moveCooldown;
        private float _attackCooldown;


        private Character _enemy;
        
        private readonly Transform _transform;
        private readonly NavMeshAgent _navMeshAgent;

        public Character(int team, float health, Transform transform, NavMeshAgent navMeshAgent)
        {
            MaxHealth = health;
            Health = MaxHealth;
            Team = team;
            _transform = transform;
            _navMeshAgent = navMeshAgent;
        }
        
        public void SetEnemy(Character enemy) => 
            _enemy = enemy;

        public void MoveToEnemy()
        {
            _navMeshAgent.SetDestination(_enemy.Position);
            _moveCooldown = UPDATE_PATH_DELAY;
        }

        public void Update()
        {
            _moveCooldown = Max(_moveCooldown - deltaTime, 0f);
            _attackCooldown = Max(_attackCooldown - deltaTime, 0f);
        }

        public void AttackEnemy()
        {
            _enemy.TakeDamage(DAMAGE);
            _attackCooldown = ATTACK_COOLDOWN;

            if (!IsEnemyAlive)
                ClearEnemy();
        }

        public void ClearEnemy() => 
            _enemy = null;

        private void TakeDamage(float amount)
        {
            Health = Max(Health - amount, 0f);
            OnHit?.Invoke();
            
            if (Approximately(Health, 0f))
                OnDie?.Invoke(this);
        }
    }
}
