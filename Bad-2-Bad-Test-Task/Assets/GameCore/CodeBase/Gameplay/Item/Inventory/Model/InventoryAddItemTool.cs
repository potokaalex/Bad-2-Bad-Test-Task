using System.Collections.Generic;
using GameCore.CodeBase.Gameplay.Item.Data;

namespace GameCore.CodeBase.Gameplay.Item.Inventory.Model
{
    public class InventoryAddItemTool
    {
        private readonly List<ItemData> _freeItemsBuffer = new();

        public void AddItem(ItemData item, ItemData[] rootItems)
        {
            var freeItems = GetFreeItems(item.Type, rootItems);

            foreach (var freeItem in freeItems)
                if (item.CurrentCount > 0)
                    Move(item, freeItem);

            if (item.CurrentCount > 0)
                if (TryGetEmptyCell(rootItems, out var index))
                    rootItems[index] = item;
        }

        private List<ItemData> GetFreeItems(ItemsType type, IEnumerable<ItemData> rootItems)
        {
            _freeItemsBuffer.Clear();

            foreach (var item in rootItems)
                if (item != null && item.Type == type)
                    _freeItemsBuffer.Add(item);

            return _freeItemsBuffer;
        }

        private void Move(ItemData from, ItemData to)
        {
            var freeSpace = to.MaxCount - to.CurrentCount;

            if (freeSpace <= from.CurrentCount)
            {
                to.CurrentCount += freeSpace;
                from.CurrentCount -= freeSpace;
            }
            else
            {
                to.CurrentCount += from.CurrentCount;
                from.CurrentCount = 0;
            }
        }

        private bool TryGetEmptyCell(IReadOnlyList<ItemData> rootItems, out int cellIndex)
        {
            for (var i = 0; i < rootItems.Count; i++)
            {
                if (rootItems[i] == null)
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