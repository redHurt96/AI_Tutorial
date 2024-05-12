using _Project.Logic.Common.Characters.Components;
using _Project.Logic.Common.Utilities;
using UnityEngine;

namespace _Project.Logic.Common.Characters.Sensors
{
    public class VisibleUnitsSensor : MonoBehaviour
    {
        [SerializeField] private VisibleUnits _visibleUnits;
        [SerializeField] private ColliderTriggerObserver _colliderTriggerObserver;

        private void Start()
        {
            _colliderTriggerObserver.OnEnter += Enter;
            _colliderTriggerObserver.OnExit += Exit;
        }

        private void OnDestroy()
        {
            _colliderTriggerObserver.OnEnter -= Enter;
            _colliderTriggerObserver.OnExit -= Exit;
        }

        private void Enter(Collider other)
        {
            if (other.TryGetComponent(out Unit unit))
                _visibleUnits.Add(unit);
        }

        private void Exit(Collider other)
        {
            if (other.TryGetComponent(out Unit unit)) 
                _visibleUnits.Remove(unit);
        }
    }
}
