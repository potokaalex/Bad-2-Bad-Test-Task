using GameCore.CodeBase.Gameplay.Item.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Item
{
    public class ItemCollisionHandler : MonoBehaviour
    {
        private ItemFactory _itemFactory;
        private ItemData _data;
        private ItemPrefabData _instance;

        public void Construct(ItemFactory itemFactory, ItemData data, ItemPrefabData instance)
        {
            _itemFactory = itemFactory;
            _data = data;
            _instance = instance;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.TryGetComponent<IItemCollector>(out var collector))
                return;

            collector.Collect(_data);
            _itemFactory.Destroy(_instance);
        }
    }
}