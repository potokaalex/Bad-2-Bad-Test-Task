using GameCore.CodeBase.Gameplay.Health.Data;
using GameCore.CodeBase.Gameplay.Inventory;
using GameCore.CodeBase.Gameplay.Weapon;

namespace GameCore.CodeBase.Gameplay.Player.Model
{
    public class PlayerModel
    {
        private readonly WeaponStaticData _weaponData;

        public PlayerModel(HealthData health, PlayerMovementModel movement,
            PlayerWeaponModel weapon, InventoryController inventory)
        {
            Health = health;
            Movement = movement;
            Weapon = weapon;
            Inventory = inventory;
        }

        public InventoryController Inventory { get; }
        
        public PlayerMovementModel Movement { get; }

        public PlayerWeaponModel Weapon { get; }

        public HealthData Health { get; }
        
        public void TakeDamage(int value)
        {
            Health.Change(value);

            //if (Health.Get() <= 0)
            //    _enemyFactory.Destroy();
            //current player saved in factory => instance  is not needed 
        }
    }
}