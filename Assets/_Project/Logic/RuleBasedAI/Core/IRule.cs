namespace _Project.Logic.RuleBasedAI.Core
{
    public interface IRule
    {
        bool Condition { get; }
        void Action();
    }
}
