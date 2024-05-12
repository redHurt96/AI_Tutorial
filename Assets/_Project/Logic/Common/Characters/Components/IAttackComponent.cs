namespace _Project.Logic.Common.Characters.Components
{
    public interface IAttackComponent
    {
        float Cooldown { get; }
        float Range { get; }
        
        void Execute(Unit target);
        void Setup(float damage, float cooldown, float range, Team team);
    }
}