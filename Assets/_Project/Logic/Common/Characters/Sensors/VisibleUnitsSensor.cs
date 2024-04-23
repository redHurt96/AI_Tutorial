using _Project.Logic.Common.Characters.Components;
using UnityEngine;

namespace _Project.Logic.Common.Characters.Sensors
{
    public class VisibleUnitsSensor : MonoBehaviour
    {
        [SerializeField] private VisibleUnits _visibleUnits;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Unit unit))
                _visibleUnits.Add(unit);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Unit unit)) 
                _visibleUnits.Remove(unit);
        }
    }
}
