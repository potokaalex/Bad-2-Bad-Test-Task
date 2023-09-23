using GameCore.CodeBase.Gameplay.Enemy.Target;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyController
    {
        private readonly EnemyModel _model;

        public EnemyController(EnemyModel model) => _model = model;

        public void Follow(EnemyTarget target) => _model.Follow(target);
    }
}