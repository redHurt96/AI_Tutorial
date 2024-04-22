using _Project.Logic.Common.Services;
using Zenject;

namespace _Project.Logic.Common
{
    public class EntryPoint : ITickable
    {
        private readonly IActorsRepository _repository;

        public EntryPoint(IActorsRepository repository) => 
            _repository = repository;

        public void Tick() => 
            _repository.ForEach(x => x.Act());
    }
}