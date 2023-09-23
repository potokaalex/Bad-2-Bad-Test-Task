using GameCore.CodeBase.Gameplay.Enemy.Data;
using GameCore.CodeBase.Gameplay.Health.Data;
using GameCore.CodeBase.Gameplay.Item;

namespace GameCore.CodeBase.Gameplay.Enemy.Model
{
    public class EnemyModel
    {
        private readonly EnemyPrefabData _instance;
        private readonly EnemyFactory _enemyFactory;
        private readonly ItemFactory _itemFactory;

        public EnemyModel(EnemyPrefabData instance, EnemyFactory enemyFactory, HealthData health,
            EnemyWeaponModel weapon, EnemyMovementModel movement,ItemFactory itemFactory)
        {
            _instance = instance;
            _enemyFactory = enemyFactory;
            _itemFactory = itemFactory;
            Health = health;

            Weapon = weapon;
            Movement = movement;
        }

        public HealthData Health { get; }

        public EnemyWeaponModel Weapon { get; }

        public EnemyMovementModel Movement { get; }

        public void TakeDamage(int value)
        {
            Health.Change(value);

            if (Health.Get() <= 0)
            {
                _enemyFactory.Destroy(_instance);
                _itemFactory.CreateGameObjectRandom(_instance.transform.position);
            }
        }
    }
}