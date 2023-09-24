using System.Collections.Generic;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Item.Data;
using GameCore.CodeBase.Gameplay.Item.Inventory;
using GameCore.CodeBase.Gameplay.Player.Data;
using GameCore.CodeBase.Gameplay.Player.Data.Static;
using GameCore.CodeBase.Gameplay.Weapon;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Model
{
    public class PlayerWeaponModel
    {
        private readonly WeaponStaticData _weaponData;
        private readonly PlayerObjectPrefabData _instance;
        private readonly InventoryController _inventory;
        private readonly List<EnemyController> _selectedEnemies = new();

        public PlayerWeaponModel(WeaponStaticData weaponData, PlayerObjectPrefabData instance,
            InventoryController inventory)
        {
            _weaponData = weaponData;
            _instance = instance;
            _inventory = inventory;
        }

        public void SelectEnemy(EnemyController enemy)
        {
            if (!_selectedEnemies.Contains(enemy))
                _selectedEnemies.Add(enemy);
        }

        public void DeselectEnemy(EnemyController enemy) => _selectedEnemies.Remove(enemy);

        public void Shoot()
        {
            if (_inventory.TryRemoveItem(ItemsType.Ammunition, 1))
                if (TryGetClosestEnemy(out var enemy))
                    enemy.TakeDamage(_weaponData.DamageValue);
        }

        private bool TryGetClosestEnemy(out EnemyController enemy)
        {
            if (_selectedEnemies.Count == 0)
            {
                enemy = null;
                return false;
            }

            enemy = _selectedEnemies[0];

            foreach (var selectedEnemy in _selectedEnemies)
            {
                var closestEnemyDistance = DistanceTo(enemy.transform);
                var currentEnemyDistance = DistanceTo(selectedEnemy.transform);

                if (currentEnemyDistance < closestEnemyDistance)
                    enemy = selectedEnemy;
            }

            return true;
        }

        private float DistanceTo(Transform targetTransform) =>
            (_instance.transform.position - targetTransform.position).magnitude;
    }
}