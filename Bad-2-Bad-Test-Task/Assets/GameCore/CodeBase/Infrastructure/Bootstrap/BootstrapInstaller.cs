using GameCore.CodeBase.Infrastructure.Services.SceneLoader;
using GameCore.CodeBase.Infrastructure.Services.StateMachine;
using GameCore.CodeBase.Infrastructure.Services.StateMachine.Factory;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoaderScreen _sceneLoaderScreenPrefab;
        [SerializeField] private ScenesStaticData _scenesStaticData;

        public override void InstallBindings()
        {
            BindStateMachine();
            BindSceneLoader();

            Container.Bind<ScenesStaticData>().FromInstance(_scenesStaticData).AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ISceneLoaderScreen>().To<SceneLoaderScreen>()
                .FromComponentInNewPrefab(_sceneLoaderScreenPrefab).AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        }
    }
}