using System.Linq;

namespace _Project.Logic.RuleBasedAI.Core
{
    public class Actor : IActor
    {
        private readonly IRule[] _rules;

        public Actor(params IRule[] rules) => 
            _rules = rules;

        public void Act() => 
            _rules
                .FirstOrDefault(x => x.Condition)
                ?.Action();
    }
}