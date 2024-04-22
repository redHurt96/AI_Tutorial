using _Project.Logic.Common.Characters;

namespace _Project.Logic.Common.Services
{
    public interface IUnitFactory
    {
        Unit Create(CreepType type, Team team);
    }
}