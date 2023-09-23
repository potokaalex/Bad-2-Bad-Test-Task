using GameCore.CodeBase.Gameplay.Health.Data;
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
            var instance = Object.Instantiate(_staticData.ObjectPrefab, spawnPoint.Value, Quaternion.identity);
            var outerCanvas = Object.Instantiate(_staticData.OuterCanvasPrefab, _playerRoot);
            var health = new HealthData(_staticData.HealthData);
            var model = new PlayerModel(instance, _staticData.MovementData, _staticData.WeaponData, health);
            var inventoryModel = new InventoryModel(_staticData.InventorySize);
            var inventory = new InventoryController(inventoryModel, outerCanvas.InventoryUI);
            var controller = instance.Controller;
            var ui = new PlayerUI(instance.InnerCanvas, outerCanvas, controller, _staticData.HealthData);

            instance.WeaponAreaHandler.Construct(controller);
            instance.ItemCollector.Construct(controller);
            controller.Construct(model, ui, inventory);

            instance.transform.SetParent(_playerRoot);

            CurrentPlayer = controller;
        }
    }
}