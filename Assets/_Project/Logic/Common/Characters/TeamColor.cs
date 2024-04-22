using UnityEngine;

namespace _Project.Logic.Common.Services
{
    public class TeamColor : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        
        public void Setup(Team team) =>
            _renderer.material.color = team is Team.Blue
                ? Color.blue 
                : Color.red;
    }
}