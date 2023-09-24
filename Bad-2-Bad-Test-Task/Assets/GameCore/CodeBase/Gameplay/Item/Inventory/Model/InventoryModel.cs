using GameCore.CodeBase.Gameplay.Item.Data;

namespace GameCore.CodeBase.Gameplay.Item.Inventory.Model
{
    public class InventoryModel
    {
        private readonly InventoryAddItemTool _addItemTool;
        private readonly InventoryRemoveItemTool _removeItemTool;

        public InventoryModel(int size)
        {
            _addItemTool = new InventoryAddItemTool();
            _removeItemTool = new InventoryRemoveItemTool();

            Items = new ItemData[size];
        }

        public ItemData[] Items { get; set; }

        public void AddItem(ItemData item) => _addItemTool.AddItem(item, Items);

        public void RemoveItem(int cellIndex) => _removeItemTool.RemoveItem(cellIndex, Items);

        public bool TryRemoveItem(ItemsType type, int count) => _removeItemTool.TryRemoveItem(type, count, Items);
    }
}