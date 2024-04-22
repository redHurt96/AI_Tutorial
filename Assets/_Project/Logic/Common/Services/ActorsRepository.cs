using System;
using System.Collections.Generic;
using _Project.Logic.Common.AI;
using RH_Modules.Utilities.Extensions;

namespace _Project.Logic.Common.Services
{
    internal class ActorsRepository : IActorsRepository
    {
        private readonly List<IActor> _actors = new();

        public void ForEach(Action<IActor> action) => 
            _actors
                .ToArray()
                .ForEach(x => x.Act());

        public void Add(IActor actor) => 
            _actors.Add(actor);

        public void Remove(IActor actor) => 
            _actors.Remove(actor);
    }
}