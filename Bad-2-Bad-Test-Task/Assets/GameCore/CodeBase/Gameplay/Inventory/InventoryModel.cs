using GameCore.CodeBase.Gameplay.Item.Data;

namespace GameCore.CodeBase.Gameplay.Inventory
{
    public class InventoryModel
    {
        private readonly ItemData[] _items;

        public InventoryModel(int size) => _items = new ItemData[size];

        public void AddItem(ItemData data)
        {
            if (TryGetFreeCell(data.Type, out var freeItem))
            {
                var freeSpace = freeItem.Static.MaxCountInStack - freeItem.CurrentCount;

                if (freeSpace < data.CurrentCount)
                {
                    freeItem.CurrentCount += freeSpace;
                    data.CurrentCount -= freeSpace;
                    AddItem(data);
                }
                else
                    freeItem.CurrentCount += data.CurrentCount;
            }
            else if (TryGetEmptyCell(out var index))
                _items[index] = data;
        }

        public void RemoveItem(int cellIndex) => _items[cellIndex] = default;

        public ItemData[] GetItems() => _items;

        private bool TryGetFreeCell(ItemsType type, out ItemData data)
        {
            foreach (var item in _items)
            {
                if (item == null)
                    continue;

                if (item.Type != type)
                    continue;

                if (item.CurrentCount >= item.Static.MaxCountInStack)
                    continue;

                data = item;
                return true;
            }

            data = default;
            return false;
        }

        private bool TryGetEmptyCell(out int cellIndex)
        {
            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i] == null)
                {
                    cellIndex = i;
                    return true;
                }
            }

            cellIndex = 0;
            return false;
        }
    }
}