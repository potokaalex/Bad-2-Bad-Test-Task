using GameCore.CodeBase.Gameplay.Camera;
using GameCore.CodeBase.Gameplay.Camera.Data;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Enemy.Data;
using GameCore.CodeBase.Gameplay.Item;
using GameCore.CodeBase.Gameplay.Item.Data;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Gameplay.Player.Data;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Infrastructure
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerStaticData _playerStaticData;
        [SerializeField] private CameraStaticData _cameraStaticData;
        [SerializeField] private EnemyStaticData _enemyStaticData;
        [SerializeField] private ItemsStaticData _itemsStaticData;

        public override void InstallBindings()
        {
            BindStaticData();

            Container.Bind<PlayerFactory>().AsSingle();
            Container.Bind<CameraFactory>().AsSingle();
            Container.Bind<EnemyFactory>().AsSingle();
            Container.Bind<ItemFactory>().AsSingle();
        }

        private void BindStaticData()
        {
            Container.Bind<PlayerStaticData>().FromInstance(_playerStaticData).AsSingle();
            Container.Bind<CameraStaticData>().FromInstance(_cameraStaticData).AsSingle();
            Container.Bind<EnemyStaticData>().FromInstance(_enemyStaticData).AsSingle();
            Container.Bind<ItemsStaticData>().FromInstance(_itemsStaticData).AsSingle();
        }
    }
}