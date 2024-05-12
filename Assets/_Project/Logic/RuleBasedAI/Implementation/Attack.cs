using _Project.Logic.Common.Characters.Components;
using static UnityEngine.Time;

namespace _Project.Logic.RuleBasedAI.Implementation
{
    internal class Attack : IRule
    {
        public bool Condition => _selectedUnit.HasTarget
                                 && _selectedUnit.Distance < _attackComponent.Range
                                 && time - _lastAttackTime > _attackComponent.Cooldown;
        
        private float _lastAttackTime;
        
        private readonly SelectedUnit _selectedUnit;
        private readonly IAttackComponent _attackComponent;
        private readonly Movement _movement;

        public Attack(SelectedUnit selectedUnit, IAttackComponent attackComponent, Movement movement)
        {
            _selectedUnit = selectedUnit;
            _attackComponent = attackComponent;
            _movement = movement;
        }

        public void Action()
        {
            _movement.Stop();
            _attackComponent.Execute(_selectedUnit.Target);
            _lastAttackTime = time;
        }
    }
}