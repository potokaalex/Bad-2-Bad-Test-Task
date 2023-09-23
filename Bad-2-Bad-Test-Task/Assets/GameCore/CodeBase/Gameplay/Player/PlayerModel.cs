using System.Collections.Generic;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Player.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerModel
    {
        private readonly PlayerObjectPrefabData _instance;
        private readonly PlayerMovementStaticData _movementData;
        private readonly PlayerWeaponStaticData _weaponData;
        private readonly List<EnemyController> _selectedEnemies = new();

        public PlayerModel(PlayerObjectPrefabData instance, PlayerMovementStaticData movementData,
            PlayerWeaponStaticData weaponData)
        {
            _instance = instance;
            _movementData = movementData;
            _weaponData = weaponData;
        }

        public GameObject GameObject => _instance.gameObject;

        public void MovePosition(Vector2 direction)
        {
            var velocity = Time.fixedDeltaTime * _movementData.PositionVelocity;
            var navMeshBugOffset = Vector2.right * 0.0001f;
            //A slight x offset to avoid BUG when strictly move along the y axis.

            var offset = direction.normalized * velocity + navMeshBugOffset;

            _instance.transform.position += new Vector3(offset.x, offset.y);
        }

        public void MoveRotation(Vector2 direction)
        {
            var oldScale = _instance.Skeleton.localScale;
            var xScale = direction.x < 0 ? -1 : 1;

            if (xScale != oldScale.x)
                _instance.Skeleton.localScale = new Vector3(xScale, oldScale.y, oldScale.z);
        }

        public void SelectEnemy(EnemyController enemy)
        {
            if (!_selectedEnemies.Contains(enemy))
                _selectedEnemies.Add(enemy);
        }

        public void DeselectEnemy(EnemyController enemy) => _selectedEnemies.Remove(enemy);

        public void Shoot()
        {
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

            for (var i = 0; i < _selectedEnemies.Count; i++)
            {
                var closestEnemyDistance = DistanceTo(enemy.transform);
                var currentEnemyDistance = DistanceTo(_selectedEnemies[i].transform);

                if (currentEnemyDistance < closestEnemyDistance)
                    enemy = _selectedEnemies[i];
            }

            return true;
        }

        private float DistanceTo(Transform targetTransform) =>
            (_instance.transform.position - targetTransform.position).magnitude;
    }
}