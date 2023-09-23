using GameCore.CodeBase.Gameplay.Inventory;
using GameCore.CodeBase.Gameplay.Item.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.InventoryUI
{
    public class PlayerInventoryUI : MonoBehaviour, IInventoryUI
    {
        [SerializeField] private PlayerInventoryCell[] _cells;
        [SerializeField] private PlayerInventoryRemoveItemButton _removeItemButton;
        private int _selectedCellIndex;

        public void Construct(PlayerController controller)
        {
            for (var i = 0; i < _cells.Length; i++)
                _cells[i].Construct(this, i);

            _removeItemButton.Construct(controller);
        }

        public void UpdateItems(ItemData[] items)
        {
            for (var i = 0; i < _cells.Length; i++)
            {
                if (items[i] == null)
                    _cells[i].RemoveItem();
                else
                    _cells[i].SetItem(items[i]);
            }
        }

        public void SelectCell(PlayerInventoryCell cell)
        {
            _cells[_selectedCellIndex].UnSelect();
            _selectedCellIndex = cell.Index;
            _cells[_selectedCellIndex].Select();

            _removeItemButton.SetCellToRemove(cell.Index);
        }
    }
}