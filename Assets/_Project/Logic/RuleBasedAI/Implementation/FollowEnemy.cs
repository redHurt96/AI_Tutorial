using _Project.Logic.Common.Characters.Components;
using static UnityEngine.Time;

namespace _Project.Logic.RuleBasedAI.Implementation
{
    internal class FollowEnemy : IRule
    {
        public bool Condition => _selectedUnit.HasTarget
                                 && _movement.HasDifferentTarget(_selectedUnit.TargetPosition)
                                 && time - _lastFollowTime > _followCooldown;
        
        private readonly SelectedUnit _selectedUnit;
        private readonly Movement _movement;
        private float _lastFollowTime;
        
        private readonly float _followCooldown = .25f;

        public FollowEnemy(SelectedUnit selectedUnit, Movement movement)
        {
            _selectedUnit = selectedUnit;
            _movement = movement;
        }

        public void Action()
        {
            _movement.Move(_selectedUnit.TargetPosition);
            _lastFollowTime = time;
        }
    }
}