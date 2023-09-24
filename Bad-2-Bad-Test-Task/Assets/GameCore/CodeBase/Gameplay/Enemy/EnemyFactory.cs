using System;
using System.Collections.Generic;
using GameCore.CodeBase.Gameplay.Enemy.Data;
using GameCore.CodeBase.Gameplay.Enemy.Model;
using GameCore.CodeBase.Gameplay.Health.Data;
using GameCore.CodeBase.Gameplay.Item;
using GameCore.CodeBase.Utilities.Scene;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyFactory
    {
        private const string EnemyRootName = "EnemyRoot";
        private readonly EnemyStaticData _staticData;
        private readonly ItemFactory _itemFactory;
        private readonly List<EnemyController> _enemies = new();
        private readonly Transform _root;

        public EnemyFactory(EnemyStaticData staticData, ItemFactory itemFactory)
        {
            _staticData = staticData;
            _itemFactory = itemFactory;
            _root = new GameObject(EnemyRootName).transform;
        }

        public int EnemiesCount => _enemies.Count;

        public void Create(SpawnPoint[] spawnPoints)
        {
            for (var i = 0; i < _staticData.EnemySpawnCount; i++)
                _enemies.Add(Create(spawnPoints[i].Value));
        }

        private EnemyController Create(Vector3 position)
        {
            var instance = CreateGameObject(position);
            var health = new HealthData(_staticData.HealthData);
            var weapon = new EnemyWeaponModel(_staticData.WeaponData);
            var movement = new EnemyMovementModel(instance);
            var model = new EnemyModel(instance, this, health, weapon, movement, _itemFactory, instance.Controller);

            instance.UI.Construct(_staticData.HealthData);
            instance.Controller.Construct(model, instance.UI);

            return instance.Controller;
        }

        public void Destroy(EnemyController controller)
        {
            _enemies.Remove(controller);
            Object.Destroy(controller.gameObject);
        }

        private EnemyPrefabData CreateGameObject(Vector3 position)
        {
            var instance = Object.Instantiate(_staticData.Prefab, position, Quaternion.identity);
            instance.transform.SetParent(_root);
            return instance;
        }
    }
}