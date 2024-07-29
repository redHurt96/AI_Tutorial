using UnityEngine;
using static UnityEngine.Object;
using static UnityEngine.Random;
using static UnityEngine.Resources;

namespace _Project.Common.Characters
{
    public class CharacterFactory
    {
        private readonly CharactersRepository _charactersRepository;

        public CharacterFactory(CharactersRepository charactersRepository) => 
            _charactersRepository = charactersRepository;

        public Character Create(int teamId)
        {
            Character character = Instantiate(
                Load<Character>("Character"),
                new(Range(-15f, 15f), 0f, Range(-15f, 15f)),
                Quaternion.identity);
            
            character.Setup(teamId);
            
            _charactersRepository.Register(character);

            return character;
        }
    }
}
