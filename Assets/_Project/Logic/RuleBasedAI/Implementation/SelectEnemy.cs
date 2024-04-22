using _Project.Logic.Common;
using _Project.Logic.Common.Characters.Components;

namespace _Project.Logic.RuleBasedAI.Implementation
{
    internal class SelectEnemy : IRule
    {
        public bool Condition => _visibleUnits.HasAnyEnemy(_team) && !_selectedUnit.HasTarget;
        
        private readonly VisibleUnits _visibleUnits;
        private readonly SelectedUnit _selectedUnit;
        private readonly Team _team;

        public SelectEnemy(VisibleUnits visibleUnits, SelectedUnit selectedUnit, Team team)
        {
            _visibleUnits = visibleUnits;
            _selectedUnit = selectedUnit;
            _team = team;
        }

        public void Action() => 
            _selectedUnit.SetTarget(_visibleUnits.GetClosestEnemy(_team));
    }
}