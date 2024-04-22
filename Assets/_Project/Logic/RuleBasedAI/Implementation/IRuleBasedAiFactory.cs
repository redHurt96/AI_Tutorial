using _Project.Logic.Common;

namespace _Project.Logic.RuleBasedAI
{
    public interface IRuleBasedAiFactory
    {
        void Spawn(Team team, CreepType type);
    }
}