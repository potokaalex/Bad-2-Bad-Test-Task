using GameCore.CodeBase.Gameplay.Item.Data;

namespace GameCore.CodeBase.Gameplay.Inventory
{
    public interface IInventoryUI
    {
        public void UpdateItems(ItemData[] items);
    }
}