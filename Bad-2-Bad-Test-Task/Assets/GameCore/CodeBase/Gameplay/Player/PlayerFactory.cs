using GameCore.CodeBase.Gameplay.Health.Data;
using GameCore.CodeBase.Gameplay.Inventory;
using GameCore.CodeBase.Gameplay.Inventory.Model;
using GameCore.CodeBase.Gameplay.Player.Data;
using GameCore.CodeBase.Gameplay.Player.Data.UI;
using GameCore.CodeBase.Gameplay.Player.Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerFactory
    {
        private const string PlayerRootName = "PlayerRoot";
        private readonly PlayerStaticData _staticData;
        private Transform _playerRoot;

        public PlayerFactory(PlayerStaticData staticData) => _staticData = staticData;

        public PlayerController CurrentPlayer { get; private set; }

        public void CreatePlayer(Vector3 position)
        {
            _playerRoot = new GameObject(PlayerRootName).transform;

            var instance = CreateGameObject(position);
            var outerCanvas = CreateOuterCanvas();
            var model = CreateModel(instance, outerCanvas);
            var controller = instance.Controller;
            var ui = new PlayerUI(instance.InnerCanvas, outerCanvas, controller, _staticData.HealthData);

            instance.Controller.Construct(model, ui);

            CurrentPlayer = controller;
        }

        public void DestroyPlayer()
        {
            Object.Destroy(_playerRoot.gameObject);
            CurrentPlayer = null;
        }

        private PlayerObjectPrefabData CreateGameObject(Vector3 position)
        {
            var instance = Object.Instantiate(_staticData.ObjectPrefab, position, Quaternion.identity);
            instance.transform.SetParent(_playerRoot);
            return instance;
        }

        private PlayerOuterCanvasPrefabData CreateOuterCanvas() =>
            Object.Instantiate(_staticData.OuterCanvasPrefab, _playerRoot);

        private InventoryController CreateInventory(IInventoryUI ui)
        {
            var model = new InventoryModel(_staticData.InventorySize);
            return new InventoryController(model, ui);
        }

        private PlayerModel CreateModel(PlayerObjectPrefabData instance,
            PlayerOuterCanvasPrefabData outerCanvas)
        {
            var inventory = CreateInventory(outerCanvas.InventoryUI);
            var movement = new PlayerMovementModel(instance, _staticData.MovementData);
            var weapon = new PlayerWeaponModel(_staticData.WeaponData, instance, inventory);
            var health = new HealthData(_staticData.HealthData);
            return new PlayerModel(health, movement, weapon, inventory, this);
        }
    }
}