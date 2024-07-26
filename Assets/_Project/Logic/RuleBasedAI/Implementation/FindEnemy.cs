using _Project.Common;
using _Project.RuleBasedAI.Core;

namespace _Project.RuleBasedAI.Implementation
{
    public class FindEnemy : IRule
    {
        public bool Condition => !_character.HasEnemy && _repository.HasAnyEnemy(_character.Team);
        
        private readonly Character _character;
        private readonly CharactersRepository _repository;

        public FindEnemy(Character character, CharactersRepository repository)
        {
            _character = character;
            _repository = repository;
        }

        public void Action()
        {
            Character enemy = _repository.SelectClosest(_character);
            _character.SetEnemy(enemy);
        }
    }
}
