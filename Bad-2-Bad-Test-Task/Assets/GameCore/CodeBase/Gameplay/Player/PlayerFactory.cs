using GameCore.CodeBase.Gameplay.Player.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerFactory
    {
        private const string PlayerRootName = "PlayerRoot";
        private readonly PlayerStaticData _staticData;
        private Transform _playerRoot;

        public PlayerFactory(PlayerStaticData staticData) => _staticData = staticData;

        public PlayerController CurrentPlayer { get; private set; }

        public void CreatePlayer(SpawnPoint spawnPoint)
        {
            var root = new GameObject(PlayerRootName).transform;
            var instance = Object.Instantiate(_staticData.ControllerPrefab, spawnPoint.Value, Quaternion.identity);
            var model = new PlayerModel(instance, _staticData.MovementData);
            var controller = new PlayerController(model);

            instance.transform.SetParent(root);
            foreach (var prefab in _staticData.UIPrefabs)
                CreateUI(prefab, controller, root);

            CurrentPlayer = controller;
            _playerRoot = root;
        }

        private void CreateUI(PlayerUIPrefabData prefab, PlayerController controller, Transform root)
        {
            var instance = Object.Instantiate(prefab, root);

            foreach (var monoUiElement in instance.UIElements)
            {
                var uiElement = monoUiElement as IPlayerUIElement;
                uiElement.Construct(controller);
            }
        }
    }
}