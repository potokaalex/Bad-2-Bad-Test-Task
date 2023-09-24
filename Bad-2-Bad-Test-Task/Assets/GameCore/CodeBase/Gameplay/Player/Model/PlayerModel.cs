using GameCore.CodeBase.Gameplay.Health.Data;
using GameCore.CodeBase.Gameplay.Item;
using GameCore.CodeBase.Gameplay.Item.Inventory;
using GameCore.CodeBase.Gameplay.Player.Data;
using GameCore.CodeBase.Gameplay.Player.Data.Static;
using GameCore.CodeBase.Gameplay.Weapon;

namespace GameCore.CodeBase.Gameplay.Player.Model
{
    public class PlayerModel
    {
        private readonly PlayerFactory _playerFactory;
        private readonly ItemFactory _itemFactory;
        private readonly PlayerStaticData _staticData;
        private readonly WeaponStaticData _weaponData;

        public PlayerModel(HealthData health, PlayerMovementModel movement, PlayerWeaponModel weapon,
            InventoryController inventory, PlayerFactory playerFactory, ItemFactory itemFactory,
            PlayerStaticData staticData)
        {
            _playerFactory = playerFactory;
            _itemFactory = itemFactory;
            _staticData = staticData;
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

            if (Health.Get() <= 0)
                _playerFactory.DestroyPlayer();
        }

        public void OnProgressLoad(PlayerProgressData progressData) =>
            Inventory.SetItems(_itemFactory.FromSaved(progressData.InventoryItems, _staticData.InventorySize));

        public void OnProgressSave(PlayerProgressData progressData) =>
            progressData.InventoryItems = _itemFactory.ToSaved(Inventory.GetItems());
    }
}