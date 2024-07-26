using _Project.Common;
using _Project.RuleBasedAI.Core;

namespace _Project.RuleBasedAI.Implementation
{
    public class AttackEnemy : IRule
    {
        public bool Condition => _character.HasEnemy 
                                 && _character.CloseToEnemy 
                                 && !_character.InAttackCooldown;
        
        private readonly Character _character;

        public AttackEnemy(Character character) => 
            _character = character;

        public void Action() => 
            _character.AttackEnemy();
    }
}