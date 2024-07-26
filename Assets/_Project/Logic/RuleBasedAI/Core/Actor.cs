using System.Linq;
using _Project.Common;
using _Project.Logic.RuleBasedAI.Core;

namespace _Project.RuleBasedAI.Core
{
    public class Actor : IActor, IAiBrain
    {
        private readonly IRule[] _rules;

        public Actor(params IRule[] rules) => 
            _rules = rules;

        public void Update() => 
            _rules
                .FirstOrDefault(x => x.Condition)
                ?.Action();
    }
}