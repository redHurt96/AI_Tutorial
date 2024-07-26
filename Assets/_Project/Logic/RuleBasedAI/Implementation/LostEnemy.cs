using _Project.Common;
using _Project.RuleBasedAI.Core;

namespace _Project.RuleBasedAI.Implementation
{
    public class LostEnemy : IRule
    {
        public bool Condition => _character.HasEnemy && !_character.IsEnemyAlive;
        
        private readonly Character _character;

        public LostEnemy(Character character) => 
            _character = character;

        public void Action() => 
            _character.ClearEnemy();
    }
}