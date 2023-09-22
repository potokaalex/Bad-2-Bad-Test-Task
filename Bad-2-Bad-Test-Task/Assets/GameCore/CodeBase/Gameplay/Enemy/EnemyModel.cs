using GameCore.CodeBase.Gameplay.Enemy.Data;
using GameCore.CodeBase.Gameplay.Enemy.Target;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyModel
    {
        private readonly EnemyPrefabData _instance;

        public EnemyModel(EnemyPrefabData instance) => _instance = instance;

        public void Follow(IEnemyTarget target) => _instance.Agent.SetDestination(target.Position);
    }
}