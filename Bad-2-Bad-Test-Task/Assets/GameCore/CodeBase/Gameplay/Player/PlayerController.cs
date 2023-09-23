using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Enemy.Target;
using GameCore.CodeBase.Gameplay.Inventory;
using GameCore.CodeBase.Gameplay.Item.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerController : MonoBehaviour, IEnemyTarget
    {
        private PlayerModel _model;
        private InventoryController _inventory;
        private PlayerUI _ui;

        public void Construct(PlayerModel model, PlayerUI ui, InventoryController inventoryController)
        {
            _model = model;
            _inventory = inventoryController;
            _ui = ui;
        }

        public InventoryController Inventory => _inventory;

        public GameObject GameObject => _model.GameObject;

        public Vector3 Position => _model.GameObject.transform.position;

        public void Move(Vector2 direction) => _model.MovePosition(direction);

        public void Rotate(Vector2 direction) => _model.MoveRotation(direction);

        public void SelectEnemy(EnemyController enemy) => _model.SelectEnemy(enemy);

        public void DeselectEnemy(EnemyController enemy) => _model.DeselectEnemy(enemy);

        public void Shoot()
        {
            if (_inventory.TryRemoveItem(ItemsType.Ammunition, 1))
                _model.Shoot();
        }

        public void TakeDamage(int value)
        {
            _model.TakeDamage(value);
            _ui.SetHealth(_model.Health.Get());
        }
    }
}