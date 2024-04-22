using System;
using UnityEngine;

namespace _Project.Logic.Common.Characters
{
    public class Unit : MonoBehaviour
    {
        public event Action<Unit> Destroyed; 

        [field:SerializeField] public Team Team { get; private set; }

        public void Setup(Team team) => 
            Team = team;

        public void Destroy()
        {
            Destroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}