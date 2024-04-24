using _Project.Logic.Common;
using _Project.Logic.Common.Characters;
using _Project.Logic.Common.Characters.Components;
using _Project.Logic.Common.Services;

namespace _Project.Logic.RuleBasedAI.Implementation
{
    internal class RuleBasedAiFactory : IRuleBasedAiFactory
    {
        private readonly UnitFactory _unitFactory;
        private readonly IActorsRepository _actorsRepository;
        private readonly IMap _map;

        public RuleBasedAiFactory(UnitFactory unitFactory, IActorsRepository actorsRepository, IMap map)
        {
            _unitFactory = unitFactory;
            _actorsRepository = actorsRepository;
            _map = map;
        }

        public void Spawn(Team team, CreepType type)
        {
            Unit unit = _unitFactory.Create(type, team);
            Movement movement = unit.GetComponent<Movement>();
            SelectedUnit selectedUnit = unit.GetComponent<SelectedUnit>();
            Actor actor = new(new MoveToMapTarget(movement, selectedUnit, team, _map),
                new SelectEnemy(unit.GetComponent<VisibleUnits>(), selectedUnit, team),
                new FollowEnemy(selectedUnit, movement),
                new Attack(selectedUnit, unit.GetComponent<IAttackComponent>()),
                new Die(unit, unit.GetComponent<Health>()));
            
            _actorsRepository.Add(actor);

            unit.Destroyed += x => _actorsRepository.Remove(actor);
        }
    }
}