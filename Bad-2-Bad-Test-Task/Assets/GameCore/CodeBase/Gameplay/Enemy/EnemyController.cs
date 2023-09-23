using GameCore.CodeBase.Gameplay.Enemy.Target;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyModel _model;

        public void Construct(EnemyModel model) => _model = model;

        public void Follow(EnemyTarget target) => _model.Follow(target);

        public void TakeDamage(int value) => _model.TakeDamage(value);
    }
}