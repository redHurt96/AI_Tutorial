using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Characters.Components;
using RH_Modules.Utilities.Extensions;
using static UnityEngine.Time;

namespace _Project.Logic.RuleBasedAI.Implementation
{
    public class Die : IRule
    {
        public bool Condition => _health.Value.ApproximatelyEqual(0f);

        private readonly Unit _unit;
        private readonly Health _health;

        public Die(Unit unit, Health health)
        {
            _unit = unit;
            _health = health;
        }

        public void Action() => 
            _unit.Destroy();
    }

    internal class Attack : IRule
    {
        public bool Condition => _selectedUnit.CloseEnoughToAttack
                                 && time - _lastAttackTime > _cooldown;
        
        private readonly SelectedUnit _selectedUnit;
        private float _lastAttackTime;
        
        private readonly float _cooldown;

        public Attack(SelectedUnit selectedUnit, float cooldown)
        {
            _selectedUnit = selectedUnit;
            _cooldown = cooldown;
        }

        public void Action()
        {
            _selectedUnit.Attack();
            _lastAttackTime = time;
        }
    }
}