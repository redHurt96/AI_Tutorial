using System;
using UnityEngine;

namespace _Project.Logic.Common.Utilities
{
    [RequireComponent(typeof(Collider))]
    public class ColliderTriggerObserver : MonoBehaviour
    {
        public event Action<Collider> OnEnter;
        public event Action<Collider> OnExit;

        private void OnTriggerEnter(Collider other) => 
            OnEnter?.Invoke(other);

        private void OnTriggerExit(Collider other) => 
            OnExit?.Invoke(other);
    }
}
