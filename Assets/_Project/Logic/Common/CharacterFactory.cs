using UnityEngine;

namespace _Project.Common
{
    public class CharacterFactory
    {
        public CharacterFactory(CharactersRepository charactersRepository)
        {
        }

        public CharacterContext Create()
        {
            CharacterContext character = new(Random.Range(0, 1), 100f);
            CharacterView characterView = Object.Instantiate(Resources.Load<CharacterView>("Character"));
            characterView.Install(character);

            return character;
        }
    }
}
