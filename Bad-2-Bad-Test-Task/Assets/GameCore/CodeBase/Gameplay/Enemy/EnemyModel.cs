using GameCore.CodeBase.Gameplay.Enemy.Data;
using GameCore.CodeBase.Gameplay.Enemy.Target;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyModel
    {
        private readonly EnemyPrefabData _instance;
        private readonly EnemyFactory _enemyFactory;

        public EnemyModel(EnemyPrefabData instance,EnemyFactory enemyFactory)
        {
            _instance = instance;
            _enemyFactory = enemyFactory;
        }

        public void Follow(EnemyTarget target)
        {
            var direction = target.Position - _instance.Agent.transform.position;

            _instance.Agent.SetDestination(target.Position);

            Rotate(direction);
        }

        private void Rotate(Vector3 moveDirection)
        {
            var oldScale = _instance.Skeleton.localScale;
            var xScale = moveDirection.x < 0 ? -1 : 1;

            if (xScale != oldScale.x)
                _instance.Skeleton.localScale = new Vector3(xScale, oldScale.y, oldScale.z);
        }

        public void TakeDamage(int value)
        {
            _enemyFactory.Destroy(_instance);
        }
    }
}