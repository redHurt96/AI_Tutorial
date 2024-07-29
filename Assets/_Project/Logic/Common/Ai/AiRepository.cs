using System.Collections.Generic;
using _Project.Common.Characters;

namespace _Project.Common.Ai
{
    public class AiRepository
    {
        public IEnumerable<IAiBrain> AiBrains => _aiBrainsPerCharacter.Values;
        
        private readonly Dictionary<Character, IAiBrain> _aiBrainsPerCharacter = new();

        public void Register(Character character, IAiBrain aiBrain)
        {
            _aiBrainsPerCharacter[character] = aiBrain;

            character.Health.OnDie += () => Unregister(character);
        }

        private void Unregister(Character character) => 
            _aiBrainsPerCharacter.Remove(character);
    }
}