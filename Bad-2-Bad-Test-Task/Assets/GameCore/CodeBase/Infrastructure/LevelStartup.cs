using GameCore.CodeBase.Gameplay;
using GameCore.CodeBase.Gameplay.Camera;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Item;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Utilities.Scene;
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
        private EnemyFactory _enemyFactory;

        [Inject]
        private void Constructor(PlayerFactory playerFactory, CameraFactory cameraFactory,
            EnemyFactory enemyFactory)
        {
            _playerFactory = playerFactory;
            _cameraFactory = cameraFactory;
            _enemyFactory = enemyFactory;
        }

        private void Start()
        {
            _playerFactory.CreatePlayer(PlayerSpawnPoint.Value);
            _cameraFactory.Create(PlayerSpawnPoint.Value, _playerFactory.CurrentPlayer);
            _enemyFactory.Create(EnemySpawnPoints);
        }
    }
}