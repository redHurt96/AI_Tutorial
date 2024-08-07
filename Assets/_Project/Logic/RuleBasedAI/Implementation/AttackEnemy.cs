using _Project.Common;
using _Project.Common.Characters;
using _Project.RuleBasedAI.Core;

namespace _Project.RuleBasedAI.Implementation
{
    public class AttackEnemy : IRule
    {
        public bool Condition => _selectedTarget.Any 
                                 && _attack.CloseEnough(_selectedTarget.Value) 
                                 && !_attack.InCooldown;
        
        private readonly SelectedTarget _selectedTarget;
        private readonly Attack _attack;

        public AttackEnemy(Character character)
        {
            _selectedTarget = character.SelectedTarget;
            _attack = character.Attack;
        }

        public void Action() => 
            _attack.Execute(_selectedTarget.Value);
    }
}