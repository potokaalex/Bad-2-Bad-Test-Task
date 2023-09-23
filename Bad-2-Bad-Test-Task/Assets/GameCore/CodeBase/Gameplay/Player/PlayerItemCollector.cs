using GameCore.CodeBase.Gameplay.Item;
using GameCore.CodeBase.Gameplay.Item.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerItemCollector : MonoBehaviour, IItemCollector
    {
        private PlayerController _controller;

        public void Construct(PlayerController controller) => _controller = controller;

        public void Collect(ItemData data) => _controller.Inventory.AddItem(data);
    }
}