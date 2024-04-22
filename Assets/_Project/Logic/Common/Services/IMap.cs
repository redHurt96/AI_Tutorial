using UnityEngine;

namespace _Project.Logic.Common
{
    public interface IMap
    {
        Vector3 TeamRedTarget { get; }
        Vector3 TeamBlueTarget { get; }
        Vector3 GetSpawnPoint(Team team);
    }
}