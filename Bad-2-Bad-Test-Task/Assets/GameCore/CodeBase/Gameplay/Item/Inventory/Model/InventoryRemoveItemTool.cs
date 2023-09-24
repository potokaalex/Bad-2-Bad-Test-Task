using GameCore.CodeBase.Gameplay.Item.Data;

namespace GameCore.CodeBase.Gameplay.Item.Inventory.Model
{
    public class InventoryRemoveItemTool
    {
        public void RemoveItem(int cellIndex, ItemData[] rootItems) => rootItems[cellIndex] = null;

        public bool TryRemoveItem(ItemsType type, int count, ItemData[] rootItems)
        {
            for (var i = 0; i < rootItems.Length; i++)
            {
                if (rootItems[i] == null || rootItems[i].Type != type)
                    continue;

                if (rootItems[i].CurrentCount > count)
                {
                    rootItems[i].CurrentCount -= count;
                    return true;
                }

                if (rootItems[i].CurrentCount == count)
                {
                    RemoveItem(i, rootItems);
                    return true;
                }

                count -= rootItems[i].MaxCount - rootItems[i].CurrentCount;
                RemoveItem(i, rootItems);
            }

            return false;
        }
    }
}