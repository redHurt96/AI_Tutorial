namespace _Project.RuleBasedAI.Core
{
    public interface IRule
    {
        bool Condition { get; }
        void Action();
    }
}
