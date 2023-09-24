using GameCore.CodeBase.Gameplay.Item.Data;
using GameCore.CodeBase.Gameplay.Item.Inventory.Model;

namespace GameCore.CodeBase.Gameplay.Item.Inventory
{
    public class InventoryController
    {
        private readonly InventoryModel _model;
        private readonly IInventoryUI _ui;

        public InventoryController(InventoryModel model, IInventoryUI ui)
        {
            _model = model;
            _ui = ui;
        }

        public void AddItem(ItemData data)
        {
            _model.AddItem(data);
            _ui.UpdateItems(_model.Items);
        }

        public void RemoveItem(int cellIndex)
        {
            _model.RemoveItem(cellIndex);
            _ui.UpdateItems(_model.Items);
        }

        public bool TryRemoveItem(ItemsType type, int count)
        {
            var result = _model.TryRemoveItem(type, count);
            _ui.UpdateItems(_model.Items);

            return result;
        }

        public ItemData[] GetItems() => _model.Items;

        public void SetItems(ItemData[] items)
        {
            _model.Items = items;
            _ui.UpdateItems(_model.Items);
        }
    }
}