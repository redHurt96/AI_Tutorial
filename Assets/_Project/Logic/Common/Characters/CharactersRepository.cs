using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Vector3;

namespace _Project.Common.Characters
{
    public class CharactersRepository
    {
        private readonly List<Character> _characters = new();

        public bool HasAnyEnemy(int forTeam) => 
            _characters.Any(x => x.Team != forTeam);

        public Character SelectClosest(Vector3 toPosition, int forTeam) =>
            _characters
                .Where(x => x.Team != forTeam)
                .OrderBy(x => Distance(toPosition, x.transform.position))
                .First();

        public void Register(Character character)
        {
            character.Health.OnDie += () => Unregister(character);
            _characters.Add(character);
        }

        private void Unregister(Character character) => 
            _characters.Remove(character);
    }
}