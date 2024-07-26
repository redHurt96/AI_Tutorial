using System.Collections.Generic;
using System.Linq;
using static UnityEngine.Vector3;

namespace _Project.Common
{
    public class CharactersRepository
    {
        public IEnumerable<Character> All => _characters;
        
        private readonly List<Character> _characters = new();

        public bool HasAnyEnemy(int forTeam) => 
            _characters.Any(x => x.Team != forTeam);

        public Character SelectClosest(Character character) =>
            _characters
                .Where(x => x.Team != character.Team)
                .OrderBy(x => Distance(x.Position, character.Position))
                .First();

        public void Register(Character character)
        {
            character.OnDie += Unregister;
            _characters.Add(character);
        }

        private void Unregister(Character character)
        {
            character.OnDie -= Unregister;

            _characters.Remove(character);
        }
    }
}