using _Project.Common.Characters;
using UnityEngine;

namespace _Project.Common
{
    public class Character : MonoBehaviour
    {
        [field:SerializeField] public Health Health { get; private set; }
        [field:SerializeField] public Movement Movement { get; private set; }
        [field:SerializeField] public SelectedTarget SelectedTarget { get; private set; }
        [field:SerializeField] public Attack Attack { get; private set; }
        [field:SerializeField] public int Team { get; private set; }

        private void Awake()
        {
            Health.OnDie += Destroy;
        }

        private void Destroy()
        {
            Health.OnDie -= Destroy;
            Destroy(gameObject);
        }

        public void Setup(int teamId) => 
            Team = teamId;
    }
}
