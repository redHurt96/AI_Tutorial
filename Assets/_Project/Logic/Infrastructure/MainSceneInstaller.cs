using _Project.Logic.Common;
using _Project.Logic.Common.Services;
using _Project.Logic.RuleBasedAI;
using _Project.Logic.RuleBasedAI.Implementation;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Infrastructure
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private Map _map;
        
        public override void InstallBindings()
        {
            Container.Bind<IMap>().FromInstance(_map).AsSingle();
            Container.Bind<IUnitFactory>().To<UnitFactory>().AsSingle();
            Container.Bind<IActorsRepository>().To<ActorsRepository>().AsSingle();
            Container.Bind<IRuleBasedAiFactory>().To<RuleBasedAiFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle();
        }
    }
}