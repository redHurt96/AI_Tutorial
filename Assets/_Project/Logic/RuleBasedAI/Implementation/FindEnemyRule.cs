using _Project.Common;
using _Project.Logic.RuleBasedAI.Core;

namespace _Project.RuleBasedAI.Implementation
{
    public class FindEnemyRule : IRule
    {
        public bool Condition => !_character.HasEnemy && _repository.HasAnyEnemy(_character.Team);
        
        private readonly CharacterContext _character;
        private readonly CharactersRepository _repository;

        public FindEnemyRule(CharacterContext character, CharactersRepository repository)
        {
            _character = character;
            _repository = repository;
        }

        public void Action()
        {
            CharacterContext enemy = _repository.SelectClosest(_character);
            _character.SetEnemy(enemy);
        }
    }
}
