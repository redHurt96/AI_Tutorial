using _Project.Common;
using _Project.RuleBasedAI.Core;

namespace _Project.RuleBasedAI.Implementation
{
    public class FollowEnemy : IRule
    {
        public bool Condition => _character.HasEnemy 
                                 && !_character.CloseToEnemy 
                                 && !_character.InMoveCooldown;
        
        private readonly Character _character;

        public FollowEnemy(Character character) => 
            _character = character;

        public void Action() => 
            _character.MoveToEnemy();
    }
}