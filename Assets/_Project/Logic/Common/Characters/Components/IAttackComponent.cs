namespace _Project.Logic.Common.Characters.Components
{
    public interface IAttackComponent
    {
        float Cooldown { get; }
        float Range { get; }
        
        void Execute(Unit target);
    }
}