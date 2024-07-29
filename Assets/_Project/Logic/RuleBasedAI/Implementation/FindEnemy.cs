using _Project.Common;
using _Project.Common.Characters;
using _Project.RuleBasedAI.Core;

namespace _Project.RuleBasedAI.Implementation
{
    public class FindEnemy : IRule
    {
        public bool Condition => !_selectedTarget.Any && _repository.HasAnyEnemy(_character.Team);

        private readonly Character _character;
        private readonly SelectedTarget _selectedTarget;
        private readonly CharactersRepository _repository;

        public FindEnemy(Character character, CharactersRepository repository)
        {
            _character = character;
            _selectedTarget = character.SelectedTarget;
            _repository = repository;
        }

        public void Action()
        {
            Character enemy = _repository.SelectClosest(_character.transform.position, _character.Team);
            _selectedTarget.Select(enemy);
        }
    }
}
