using _Project.Logic.Common;
using _Project.Logic.Common.Characters.Components;
using UnityEngine;
using static _Project.Logic.Common.Team;

namespace _Project.Logic.RuleBasedAI.Implementation
{
    internal class MoveToMapTarget : IRule
    {
        public bool Condition => _movement.HasDifferentTarget(_target) && !_selectedUnit.HasTarget;
        
        private readonly Movement _movement;
        private readonly SelectedUnit _selectedUnit;
        private readonly Vector3 _target; 

        public MoveToMapTarget(Movement movement, SelectedUnit selectedUnit, Team team, IMap map)
        {
            _movement = movement;
            _selectedUnit = selectedUnit;
            _target = team is Blue
                ? map.TeamBlueTarget
                : map.TeamRedTarget;
        }

        public void Action() => 
            _movement.Move(_target);
    }
}