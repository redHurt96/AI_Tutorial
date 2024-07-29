using _Project.Common;
using _Project.Common.Characters;
using _Project.RuleBasedAI.Core;

namespace _Project.RuleBasedAI.Implementation
{
    public class FollowEnemyRule : IRule
    {
        public bool Condition => _selectedTarget.Value != null 
                                 && !_attack.CloseEnough(_selectedTarget.Value);
        
        private readonly Movement _movement;
        private readonly SelectedTarget _selectedTarget;
        private readonly Attack _attack;

        public FollowEnemyRule(Character character)
        {
            _movement = character.Movement;
            _selectedTarget = character.SelectedTarget;
            _attack = character.Attack;
        }

        public void Action() => 
            _movement.MoveTo(_selectedTarget.Value);
    }
}