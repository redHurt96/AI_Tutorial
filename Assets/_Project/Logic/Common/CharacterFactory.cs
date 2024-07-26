using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Object;
using static UnityEngine.Random;
using static UnityEngine.Resources;

namespace _Project.Common
{
    public class CharacterFactory
    {
        private readonly CharactersRepository _charactersRepository;

        public CharacterFactory(CharactersRepository charactersRepository) => 
            _charactersRepository = charactersRepository;

        public Character Create(int teamId)
        {
            CharacterView characterView = Instantiate(
                Load<CharacterView>("Character"),
                new(Range(-15f, 15f), 0f, Range(-15f, 15f)),
                Quaternion.identity);
            
            Character character = new(
                teamId, 
                100f, 
                characterView.transform,
                characterView.GetComponent<NavMeshAgent>());
            
            characterView.Install(character);
            _charactersRepository.Register(character);

            return character;
        }
    }
}
