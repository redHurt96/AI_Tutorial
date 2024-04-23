using System.Collections.Generic;
using System.Linq;
using RH_Modules.Utilities.Attributes;
using UnityEngine;
using static UnityEngine.Vector3;

namespace _Project.Logic.Common.Characters.Components
{
    public class VisibleUnits : MonoBehaviour
    {
        [SerializeField, ReadOnly] private List<Unit> _units = new();

        public void Add(Unit unit)
        {
            _units.Add(unit);
            unit.Destroyed += Remove;
        }

        public void Remove(Unit unit)
        {
            unit.Destroyed -= Remove;
            _units.Remove(unit);
        }

        public bool HasAnyEnemy(Team team) => 
            _units.Any(x => x.Team != team);

        public Unit GetClosestEnemy(Team team) => _units
            .Where(x => x.Team != team)
            .OrderBy(x => Distance(x.transform.position, transform.position))
            .FirstOrDefault();

    }
}