using GameCore.CodeBase.Gameplay.Item.Data;

namespace GameCore.CodeBase.Gameplay.Inventory.Model
{
    public class InventoryModel
    {
        private readonly InventoryAddItemTool _addItemTool;
        private readonly InventoryRemoveItemTool _removeItemTool;
        private readonly ItemData[] _items;

        public InventoryModel(int size)
        {
            _items = new ItemData[size];
            _addItemTool = new InventoryAddItemTool();
            _removeItemTool = new InventoryRemoveItemTool();
        }

        public void AddItem(ItemData item) => _addItemTool.AddItem(item, _items);

        public void RemoveItem(int cellIndex) => _removeItemTool.RemoveItem(cellIndex, _items);

        public bool TryRemoveItem(ItemsType type, int count) => _removeItemTool.TryRemoveItem(type, count, _items);

        public ItemData[] GetItems() => _items;
    }
}