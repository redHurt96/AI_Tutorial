using UnityEngine;

namespace _Project.Common
{
    public class CharacterContext
    {
        public bool HasEnemy => _enemy is { IsAlive: true };
        public bool IsAlive => Health > 0f;
        public float Health { get; }
        public Vector3 Position { get; private set; }
        
        public readonly int Team;
        
        private CharacterContext _enemy;

        public CharacterContext(int team, float health)
        {
            Health = health;
            Team = team;
        }

        public void SetEnemy(CharacterContext enemy) => 
            _enemy = enemy;

        public void SetPosition(Vector3 toValue) => 
            Position = toValue;
    }
}
