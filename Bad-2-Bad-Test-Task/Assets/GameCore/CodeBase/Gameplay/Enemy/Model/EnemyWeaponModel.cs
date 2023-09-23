using GameCore.CodeBase.Gameplay.Enemy.Target;
using GameCore.CodeBase.Gameplay.Weapon;

namespace GameCore.CodeBase.Gameplay.Enemy.Model
{
    public class EnemyWeaponModel
    {
        private readonly WeaponStaticData _weaponStaticData;
        private IEnemyTarget _currentTarget;
        private float _timeToAttack;

        public EnemyWeaponModel(WeaponStaticData weaponStaticData) => _weaponStaticData = weaponStaticData;

        public void UpdateModel(float deltaTime)
        {
            if (_timeToAttack > 0)
            {
                _timeToAttack -= deltaTime;
                return;
            }

            if (_currentTarget == null)
                return;

            _currentTarget.TakeDamage(_weaponStaticData.DamageValue);
            ResetTimeToAttack();
        }

        public void SetTargetToAttack(IEnemyTarget target)
        {
            _currentTarget = target;
            ResetTimeToAttack();
        }

        public void RemoveTargetToAttack() => _currentTarget = null;

        private void ResetTimeToAttack() => _timeToAttack = _weaponStaticData.AttackRateSeconds;
    }
}