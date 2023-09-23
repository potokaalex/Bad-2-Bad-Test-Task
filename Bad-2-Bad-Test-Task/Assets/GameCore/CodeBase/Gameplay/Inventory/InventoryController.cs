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
    }
}