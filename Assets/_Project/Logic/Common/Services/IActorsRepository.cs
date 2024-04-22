using System;
using _Project.Logic.Common.AI;

namespace _Project.Logic.Common.Services
{
    public interface IActorsRepository
    {
        void ForEach(Action<IActor> action);
        void Add(IActor actor);
        void Remove(IActor actor);
    }
}