using GameCore.CodeBase.Gameplay;
using GameCore.CodeBase.Gameplay.Camera;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Item;
using GameCore.CodeBase.Gameplay.Item.Data;
using GameCore.CodeBase.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        public SpawnPoint PlayerSpawnPoint;
        public SpawnPoint[] EnemySpawnPoints;

        private PlayerFactory _playerFactory;
        private CameraFactory _cameraFactory;
        private ItemFactory _itemFactory;
        private EnemyFactory _enemyFactory;

        [Inject]
        private void Constructor(PlayerFactory playerFactory, CameraFactory cameraFactory, ItemFactory itemFactory,EnemyFactory enemyFactory)
        {
            _playerFactory = playerFactory;
            _cameraFactory = cameraFactory;
            _itemFactory = itemFactory;
            _enemyFactory = enemyFactory;
        }

        private void Start()
        {
            _playerFactory.CreatePlayer(PlayerSpawnPoint);
            _cameraFactory.Create(PlayerSpawnPoint, _playerFactory.CurrentPlayer);
            _enemyFactory.Create(EnemySpawnPoints);
        }
    }
}