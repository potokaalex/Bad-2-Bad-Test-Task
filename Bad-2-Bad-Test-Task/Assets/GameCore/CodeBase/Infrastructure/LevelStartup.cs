using GameCore.CodeBase.Gameplay.Camera;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Gameplay.SpawnPoint;
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

        [Inject]
        private void Constructor(PlayerFactory playerFactory, CameraFactory cameraFactory)
        {
            _playerFactory = playerFactory;
            _cameraFactory = cameraFactory;
        }

        private void Start()
        {
            _playerFactory.CreatePlayer(PlayerSpawnPoint);
            _cameraFactory.Create(PlayerSpawnPoint, _playerFactory.CurrentPlayer);
        }
    }
}