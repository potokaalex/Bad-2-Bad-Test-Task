using GameCore.CodeBase.Gameplay.Inventory;
using GameCore.CodeBase.Gameplay.Item.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerController
    {
        private readonly PlayerModel _model;

        public PlayerController(PlayerModel model, InventoryController inventoryController)
        {
            _model = model;
            Inventory = inventoryController;
        }

        public InventoryController Inventory { get; }

        public GameObject GameObject => _model.GameObject;

        public void Move(Vector2 direction) => _model.MovePosition(direction);

        public void Rotate(Vector2 direction) => _model.MoveRotation(direction);
    }
}