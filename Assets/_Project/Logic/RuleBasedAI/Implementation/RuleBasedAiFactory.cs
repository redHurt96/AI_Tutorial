using _Project.Common;
using _Project.Common.Ai;
using _Project.Common.Characters;
using _Project.RuleBasedAI.Core;

namespace _Project.RuleBasedAI.Implementation
{
    public class RuleBasedAiFactory
    {
        private readonly CharacterFactory _characterFactory;
        private readonly CharactersRepository _charactersRepository;
        private readonly AiRepository _aiRepository;

        public RuleBasedAiFactory(
            CharacterFactory characterFactory, 
            CharactersRepository charactersRepository,
            AiRepository aiRepository)
        {
            _characterFactory = characterFactory;
            _charactersRepository = charactersRepository;
            _aiRepository = aiRepository;
        }

        public void Create(int teamId)
        {
            Character character = _characterFactory.Create(teamId);
            Actor actor = new(new FindEnemy(character, _charactersRepository),
                new FollowEnemyRule(character),
                new AttackEnemy(character));
            
            _aiRepository.Register(character, actor);
        }
    }
}