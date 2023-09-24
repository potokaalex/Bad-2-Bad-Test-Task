using GameCore.CodeBase.Gameplay.Camera;
using GameCore.CodeBase.Gameplay.Camera.Data;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Enemy.Data;
using GameCore.CodeBase.Gameplay.Item;
using GameCore.CodeBase.Gameplay.Item.Data.Static;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Gameplay.Player.Data;
using GameCore.CodeBase.Gameplay.Player.Data.Static;
using GameCore.CodeBase.Infrastructure.Services.SceneLoader;
using GameCore.CodeBase.Infrastructure.Services.StateMachine;
using GameCore.CodeBase.Infrastructure.Services.StateMachine.Factory;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerStaticData _playerStaticData;
        [SerializeField] private CameraStaticData _cameraStaticData;
        [SerializeField] private EnemyStaticData _enemyStaticData;
        [SerializeField] private ItemsStaticData _itemsStaticData;
        [SerializeField] private LevelData _data;

        public override void InstallBindings()
        {
            BindStaticData();
            BindStateMachine();

            Container.Bind<PlayerFactory>().AsSingle();
            Container.Bind<CameraFactory>().AsSingle();
            Container.Bind<EnemyFactory>().AsSingle();
            Container.Bind<ItemFactory>().AsSingle();
            Container.Bind<LevelData>().FromInstance(_data).AsSingle();
            Container.Bind<LevelFactory>().AsSingle();
        }

        private void BindStaticData()
        {
            Container.Bind<PlayerStaticData>().FromInstance(_playerStaticData).AsSingle();
            Container.Bind<CameraStaticData>().FromInstance(_cameraStaticData).AsSingle();
            Container.Bind<EnemyStaticData>().FromInstance(_enemyStaticData).AsSingle();
            Container.Bind<ItemsStaticData>().FromInstance(_itemsStaticData).AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        }
    }
}