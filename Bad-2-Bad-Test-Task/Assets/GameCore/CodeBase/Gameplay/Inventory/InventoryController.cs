using GameCore.CodeBase.Gameplay.Inventory.Model;
using GameCore.CodeBase.Gameplay.Item.Data;

namespace GameCore.CodeBase.Gameplay.Inventory
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
            _ui.UpdateItems(_model.GetItems());
        }

        public void RemoveItem(int cellIndex)
        {
            _model.RemoveItem(cellIndex);
            _ui.UpdateItems(_model.GetItems());
        }

        public bool TryRemoveItem(ItemsType type, int count)
        {
            var result = _model.TryRemoveItem(type, count);
            _ui.UpdateItems(_model.GetItems());

            return result;
        }
    }
}