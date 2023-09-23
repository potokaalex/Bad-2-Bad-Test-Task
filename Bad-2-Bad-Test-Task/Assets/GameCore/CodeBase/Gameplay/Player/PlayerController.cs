using System;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Inventory;
using GameCore.CodeBase.Gameplay.Item.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerController
    {
        private readonly PlayerModel _model;
        private readonly InventoryController _inventory;

        public PlayerController(PlayerModel model, InventoryController inventoryController)
        {
            _model = model;
            _inventory = inventoryController;
        }

        public InventoryController Inventory => _inventory;

        public GameObject GameObject => _model.GameObject;

        public void Move(Vector2 direction) => _model.MovePosition(direction);

        public void Rotate(Vector2 direction) => _model.MoveRotation(direction);

        public void SelectEnemy(EnemyController enemy) => _model.SelectEnemy(enemy);

        public void DeselectEnemy(EnemyController enemy) => _model.DeselectEnemy(enemy);

        public void Shoot()
        {
            if (_inventory.TryRemoveItem(ItemsType.Ammunition, 1))
                _model.Shoot();
        }
    }
}