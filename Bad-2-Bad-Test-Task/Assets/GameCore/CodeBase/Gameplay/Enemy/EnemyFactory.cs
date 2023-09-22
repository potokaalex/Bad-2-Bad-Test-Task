using GameCore.CodeBase.Gameplay.Enemy.Data;
using GameCore.CodeBase.Gameplay.SpawnPoint;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyFactory
    {
        private const string EnemyRootName = "EnemyRoot";
        private readonly EnemyStaticData _staticData;
        private readonly EnemyController[] _enemies;
        private readonly Transform _root;

        public EnemyFactory(EnemyStaticData staticData)
        {
            _staticData = staticData;
            _root = new GameObject(EnemyRootName).transform;
            _enemies = new EnemyController[staticData.MaxEnemyCount];
        }

        public void Create(SpawnPoint.SpawnPoint[] spawnPoints)
        {
            for (var i = 0; i < _enemies.Length; i++)
                Create(spawnPoints[i]);
        }

        private void Create(ISpawnPoint spawnPoint)
        {
            var instance = Object.Instantiate(_staticData.Prefab, spawnPoint.Value, Quaternion.identity);
            var model = new EnemyModel(instance);
            var controller = new EnemyController(model);

            instance.transform.SetParent(_root);
            instance.TargetHandler.Construct(controller);
        }
    }
}