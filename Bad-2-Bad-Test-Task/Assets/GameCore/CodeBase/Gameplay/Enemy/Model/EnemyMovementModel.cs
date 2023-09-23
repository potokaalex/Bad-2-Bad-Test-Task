using GameCore.CodeBase.Gameplay.Enemy.Data;
using GameCore.CodeBase.Gameplay.Enemy.Target;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Model
{
    public class EnemyMovementModel
    {
        private readonly EnemyPrefabData _instance;
        private IEnemyTarget _currentTarget;

        public EnemyMovementModel(EnemyPrefabData instance) => _instance = instance;

        public void SetTargetToFollow(IEnemyTarget target) => _currentTarget = target;

        public void RemoveTargetToFollow() => _currentTarget = null;

        public void UpdateModel()
        {
            if(_currentTarget == null)
                return;
            
            var direction = _currentTarget.Position - _instance.Agent.transform.position;

            _instance.Agent.SetDestination(_currentTarget.Position);

            Rotate(direction);
        }
        
        private void Rotate(Vector3 moveDirection)
        {
            var oldScale = _instance.Skeleton.localScale;
            var xScale = moveDirection.x < 0 ? -1 : 1;

            if (xScale != oldScale.x)
                _instance.Skeleton.localScale = new Vector3(xScale, oldScale.y, oldScale.z);
        }
    }
}