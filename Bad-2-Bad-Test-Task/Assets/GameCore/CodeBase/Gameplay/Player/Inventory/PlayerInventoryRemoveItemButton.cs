using GameCore.CodeBase.Utilities.UI;

namespace GameCore.CodeBase.Gameplay.Player.Inventory
{
    public class PlayerInventoryRemoveItemButton : ButtonBase
    {
        private PlayerController _controller;
        private int _currentCellIndex;

        public void Construct(PlayerController controller) => _controller = controller;

        private protected override void OnClick() => _controller.Inventory.RemoveItem(_currentCellIndex);

        public void SetCellToRemove(int cellIndex) => _currentCellIndex = cellIndex;
    }
}