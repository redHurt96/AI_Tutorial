using System;
using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Characters.Components;
using _Project.Logic.Common.Configs;
using Zenject;

namespace _Project.Logic.Common.Services
{
    public class UnitFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IMap _map;
        private readonly UnitsConfig _config;

        public UnitFactory(IInstantiator instantiator, IMap map, UnitsConfig config)
        {
            _instantiator = instantiator; 
            _map = map;
            _config = config;
        }

        public Unit Create(CreepType type, Team team)
        {
            Unit unit = _instantiator.InstantiatePrefabResourceForComponent<Unit>(type.ToString());
            UnitConfig config;

            switch (type)
            {
                case CreepType.Melee:
                    config = _config.Melee;
                    unit
                        .GetComponent<Movement>()
                        .Move(_map.GetSpawnPoint(team), true);
                    break;
                case CreepType.Range:
                    config = _config.Range;
                    unit
                        .GetComponent<Movement>()
                        .Move(_map.GetSpawnPoint(team), true);
                    break;
                case CreepType.Tower:
                    config = _config.Tower;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            unit.Setup(team);
            unit
                .GetComponent<Health>()
                .Setup(config.Health);
            unit
                .GetComponent<IAttackComponent>()
                .Setup(config.Damage, config.Cooldown, config.Range);
            unit
                .GetComponent<TeamColor>()
                .Setup(team);
            
            return unit;
        }
    }
}