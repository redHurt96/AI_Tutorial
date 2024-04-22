using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Characters.Components;
using Zenject;

namespace _Project.Logic.Common.Services
{
    public class UnitFactory : IUnitFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IMap _map;

        public UnitFactory(IInstantiator instantiator, IMap map)
        {
            _instantiator = instantiator; 
            _map = map;
        }

        public Unit Create(CreepType type, Team team)
        {
            Unit unit = _instantiator.InstantiatePrefabResourceForComponent<Unit>(type.ToString());

            unit.Setup(team);
            unit
                .GetComponent<Movement>()
                .Move(_map.GetSpawnPoint(team), true);
            unit
                .GetComponent<SelectedUnit>()
                .Setup(3f, 3f);
            unit
                .GetComponent<Health>()
                .Setup(10f);
            unit
                .GetComponent<TeamColor>()
                .Setup(team);

            return unit;
        }
    }
}