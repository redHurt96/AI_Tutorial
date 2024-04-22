using RH_Modules.Utilities.Extensions;
using UnityEngine;
using static _Project.Logic.Common.Team;

namespace _Project.Logic.Common
{
    internal class Map : MonoBehaviour, IMap
    {
        public Vector3 TeamRedTarget => _teamRedTarget.position;
        public Vector3 TeamBlueTarget => _teamBlueTarget.position;
        public Vector3 GetSpawnPoint(Team team) => 
            (team is Blue 
                ? _teamBlue 
                : _teamRed)
            .GetRandom()
            .position;

        [SerializeField] private Transform[] _teamRed;
        [SerializeField] private Transform[] _teamBlue;
        
        [SerializeField] private Transform _teamRedTarget;
        [SerializeField] private Transform _teamBlueTarget;
    }
}
