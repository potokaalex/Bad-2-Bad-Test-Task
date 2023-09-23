using GameCore.CodeBase.Gameplay.Enemy.Target;

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
            _timeToAttack = _weaponStaticData.AttackRateSeconds;
        }

        public void SetTargetToAttack(IEnemyTarget target)
        {
            _currentTarget = target;
            _timeToAttack = 0;
        }

        public void RemoveTargetToAttack() => _currentTarget = null;
    }
}