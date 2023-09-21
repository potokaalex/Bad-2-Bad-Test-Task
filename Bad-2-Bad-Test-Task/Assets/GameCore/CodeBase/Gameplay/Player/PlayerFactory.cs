using GameCore.CodeBase.Gameplay.Player.Data;
using GameCore.CodeBase.Gameplay.Player.Model;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerFactory
    {
        private readonly PlayerStaticData _staticData;

        public PlayerFactory(PlayerStaticData staticData) => _staticData = staticData;

        public PlayerController CurrentPlayer { get; private set; }

        public void CreatePlayer(ISpawnPoint spawnPoint)
        {
            var instance = Object.Instantiate(_staticData.ControllerPrefab, spawnPoint.Value, Quaternion.identity);
            var model = new PlayerModel(instance, _staticData.MovementData);
            var controller = new PlayerController(model);

            foreach (var prefab in _staticData.UIPrefabs)
                CreateUI(prefab, controller);

            CurrentPlayer = controller;
        }

        private void CreateUI(PlayerUIPrefabData prefab, PlayerController controller)
        {
            var instance = Object.Instantiate(prefab);

            foreach (var monoUiElement in instance.UIElements)
            {
                var uiElement = monoUiElement as IPlayerUIElement;
                uiElement.Construct(controller);
            }
        }
    }
}