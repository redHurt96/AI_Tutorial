using System.Collections.Generic;

namespace _Project.Common
{
    public class AiRepository
    {
        public IEnumerable<IAiBrain> AiBrains => _aiBrainsPerCharacter.Values;
        
        private readonly Dictionary<Character, IAiBrain> _aiBrainsPerCharacter = new();

        public void Register(Character character, IAiBrain aiBrain)
        {
            _aiBrainsPerCharacter[character] = aiBrain;

            character.OnDie += Unregister;
        }

        private void Unregister(Character character)
        {
            character.OnDie -= Unregister;
            
            _aiBrainsPerCharacter.Remove(character);
        }
    }
}