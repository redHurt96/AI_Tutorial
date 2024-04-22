namespace _Project.Logic.RuleBasedAI
{
    public interface IRule
    {
        bool Condition { get; }
        void Action();
    }
}
