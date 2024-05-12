using RH_Modules.Utilities.Extensions;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Logic.Common.Characters.Components
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour, IComponent
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public void Move(Vector3 toTarget, bool instant = false)
        {
            _navMeshAgent.isStopped = false;

            if (instant)
                _navMeshAgent.Warp(toTarget);
            else
                _navMeshAgent.SetDestination(toTarget);
        }

        public bool HasDifferentTarget(Vector3 targetPosition) => 
            _navMeshAgent.destination.ToXY() != targetPosition.ToXY();

        public void Stop() => 
            _navMeshAgent.isStopped = true;
    }
}