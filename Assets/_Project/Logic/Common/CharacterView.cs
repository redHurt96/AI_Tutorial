using System.Linq;
using UnityEngine;

namespace _Project.Common
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private HealthView _healthView;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private TeamColor[] _teamColors;
        
        public void Install(Character character)
        {
            _renderer.material.color = _teamColors
                .First(x => x.Team == character.Team)
                .Color;

            _healthView.Install(character);
        }
    }
}