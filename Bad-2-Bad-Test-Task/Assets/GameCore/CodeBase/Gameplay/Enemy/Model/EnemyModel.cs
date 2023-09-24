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
        private readonly EnemyController _controller;

        public EnemyModel(EnemyPrefabData instance, EnemyFactory enemyFactory, HealthData health,
            EnemyWeaponModel weapon, EnemyMovementModel movement, ItemFactory itemFactory, EnemyController controller)
        {
            _instance = instance;
            _enemyFactory = enemyFactory;
            _itemFactory = itemFactory;
            _controller = controller;
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
                _enemyFactory.Destroy(_controller);
                _itemFactory.CreateGameObjectRandom(_instance.transform.position);
            }
        }
    }
}