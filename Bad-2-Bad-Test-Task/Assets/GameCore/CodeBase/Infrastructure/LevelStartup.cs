using GameCore.CodeBase.Gameplay;
using GameCore.CodeBase.Gameplay.Camera;
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

        [Inject]
        private void Constructor(PlayerFactory playerFactory, CameraFactory cameraFactory, ItemFactory itemFactory)
        {
            _playerFactory = playerFactory;
            _cameraFactory = cameraFactory;
            _itemFactory = itemFactory;
        }

        private void Start()
        {
            _playerFactory.CreatePlayer(PlayerSpawnPoint);
            _cameraFactory.Create(PlayerSpawnPoint, _playerFactory.CurrentPlayer);

            var item = _itemFactory.CreateData(ItemsType.ZombieHead, 1);
            _playerFactory.CurrentPlayer.Inventory.AddItem(item);
        }
    }
}