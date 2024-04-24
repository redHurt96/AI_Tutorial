using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Characters.Components;
using RH_Modules.Utilities.Extensions;

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
}