using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Common
{
    public class CharactersRepository
    {
        private readonly List<CharacterContext> _characters = new();

        public bool HasAnyEnemy(int forTeam) => 
            _characters.Any(x => x.Team != forTeam);

        public CharacterContext SelectClosest(CharacterContext character) =>
            _characters
                .Where(x => x.Team != character.Team)
                .OrderBy(x => Vector3.Distance(x.Position, character.Position))
                .First();
    }
}