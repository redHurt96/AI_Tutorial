using RH_Modules.Utilities.Attributes;
using UnityEngine;

namespace _Project.Logic.Common.Characters.Components
{
    public class SelectedUnit : MonoBehaviour
    {
        public bool HasTarget => Target != null;
        public Vector3 TargetPosition => Target.transform.position;
        public float Distance => Vector3.Distance(Target.transform.position, transform.position);

        [field:SerializeField, ReadOnly] public Unit Target { get; private set; }
        
        public void SetTarget(Unit value)
        {
            Target = value;
            value.Destroyed += Clear;
        }

        private void Clear(Unit target)
        {
            target.Destroyed += Clear;
            Target = null;
        }
    }
}