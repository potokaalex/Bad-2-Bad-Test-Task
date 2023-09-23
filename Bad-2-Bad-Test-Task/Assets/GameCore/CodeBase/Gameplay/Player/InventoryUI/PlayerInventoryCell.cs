using GameCore.CodeBase.Gameplay.Item.Data;
using GameCore.CodeBase.Utilities.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.CodeBase.Gameplay.Player.InventoryUI
{
    public class PlayerInventoryCell : ButtonBase
    {
        [SerializeField] private TextMeshProUGUI _itemCount;
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Color _selectBackgroundColor;
        private PlayerInventoryUI _ui;
        private Color _defaultBackgroundColor;

        public void Construct(PlayerInventoryUI ui, int index)
        {
            _ui = ui;
            _defaultBackgroundColor = _backgroundImage.color;
            Index = index;
        }

        public int Index { get; private set; }

        private protected override void OnClick() => _ui.SelectCell(this);

        public void SetItem(ItemData item)
        {
            if (item.CurrentCount > 1)
                _itemCount.text = item.CurrentCount.ToString();

            _itemIcon.sprite = item.Static.Icon;
            _itemIcon.enabled = true;
        }

        public void RemoveItem()
        {
            _itemCount.text = string.Empty;
            _itemIcon.enabled = false;
        }

        public void Select() => _backgroundImage.color = _selectBackgroundColor;

        public void UnSelect() => _backgroundImage.color = _defaultBackgroundColor;
    }
}