using GameCore.CodeBase.Gameplay.Enemy.Data;
using GameCore.CodeBase.Gameplay.Enemy.Model;
using GameCore.CodeBase.Gameplay.Health.Data;
using GameCore.CodeBase.Gameplay.Item;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyFactory
    {
        private const string EnemyRootName = "EnemyRoot";
        private readonly EnemyStaticData _staticData;
        private readonly ItemFactory _itemFactory;
        private readonly EnemyController[] _enemies;
        private readonly Transform _root;

        public EnemyFactory(EnemyStaticData staticData, ItemFactory itemFactory)
        {
            _staticData = staticData;
            _itemFactory = itemFactory;
            _root = new GameObject(EnemyRootName).transform;
            _enemies = new EnemyController[staticData.MaxEnemyCount];
        }

        public void Create(SpawnPoint[] spawnPoints)
        {
            for (var i = 0; i < _enemies.Length; i++)
                Create(spawnPoints[i]);
        }

        private void Create(ISpawnPoint spawnPoint)
        {
            var instance = Object.Instantiate(_staticData.Prefab, spawnPoint.Value, Quaternion.identity);
            var health = new HealthData(_staticData.HealthData);
            var weapon = new EnemyWeaponModel(_staticData.WeaponData);
            var movement = new EnemyMovementModel(instance);
            var model = new EnemyModel(instance, this, health, weapon, movement, _itemFactory);

            instance.UI.Construct(_staticData.HealthData);
            instance.Controller.Construct(model, instance.UI);
            instance.transform.SetParent(_root);
        }

        public void Destroy(EnemyPrefabData instance) => Object.Destroy(instance.gameObject);
    }
}