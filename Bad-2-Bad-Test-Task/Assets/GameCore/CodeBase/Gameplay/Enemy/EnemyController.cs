using GameCore.CodeBase.Gameplay.Enemy.Model;
using GameCore.CodeBase.Gameplay.Enemy.Target;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyModel _model;
        private EnemyUI _ui;

        public void Construct(EnemyModel model, EnemyUI ui)
        {
            _model = model;
            _ui = ui;
        }

        public void SetTargetToFollow(IEnemyTarget target) => _model.Movement.SetTargetToFollow(target);

        public void RemoveTargetToFollow() => _model.Movement.RemoveTargetToFollow();

        public void SetTargetToAttack(IEnemyTarget target) => _model.Weapon.SetTargetToAttack(target);

        public void RemoveTargetToAttack() => _model.Weapon.RemoveTargetToAttack();

        public void TakeDamage(int value)
        {
            _model.TakeDamage(value);
            _ui.SetHealth(_model.Health.Get());
        }

        public void UpdateModel(float deltaTime)
        {
            _model.Weapon.UpdateModel(deltaTime);
            _model.Movement.UpdateModel();
        }
    }
}