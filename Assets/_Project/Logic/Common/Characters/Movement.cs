using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Common.Characters
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _updatePathDelay = .2f;

        private float _moveCooldown;

        public void MoveTo(Character target)
        {
            if (Approximately(_moveCooldown, 0f))
            {
                _navMeshAgent.SetDestination(target.transform.position);
                _moveCooldown = _updatePathDelay;
            }
        }

        private void Update() => 
            _moveCooldown = Max(_moveCooldown - deltaTime, 0f);
    }
}