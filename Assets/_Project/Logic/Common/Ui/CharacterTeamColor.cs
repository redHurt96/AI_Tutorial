using System.Linq;
using UnityEngine;

namespace _Project.Common.Ui
{
    public class CharacterTeamColor : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private TeamColor[] _teamColors;
        
        private void Start() =>
            _renderer.material.color = _teamColors
                .First(x => x.Team == _character.Team)
                .Color;
    }
}