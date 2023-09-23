using GameCore.CodeBase.Gameplay.Inventory;
using GameCore.CodeBase.Gameplay.Player.Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerFactory
    {
        private const string PlayerRootName = "PlayerRoot";
        private readonly PlayerStaticData _staticData;
        private Transform _playerRoot;

        public PlayerFactory(PlayerStaticData staticData)
        {
            _staticData = staticData;
            _playerRoot = new GameObject(PlayerRootName).transform;
        }

        public PlayerController CurrentPlayer { get; private set; }

        public void CreatePlayer(SpawnPoint spawnPoint)
        {
            var instance = Object.Instantiate(_staticData.ControllerPrefab, spawnPoint.Value, Quaternion.identity);
            var outerCanvas = Object.Instantiate(_staticData.OuterCanvasPrefab, _playerRoot);
            var model = new PlayerModel(instance, _staticData.MovementData);
            var inventoryModel = new InventoryModel(_staticData.InventorySize);
            var inventory = new InventoryController(inventoryModel, outerCanvas.InventoryUI);
            var controller = new PlayerController(model, inventory);

            instance.ItemCollector.Construct(controller);
            outerCanvas.InventoryUI.Construct(controller);

            foreach (var device in outerCanvas.InputDevices)
            {
                device.Construct(controller);
            }

            instance.transform.SetParent(_playerRoot);

            CurrentPlayer = controller;
        }
    }
}