using GameCore.CodeBase.Gameplay.Item.Data;

namespace GameCore.CodeBase.Gameplay.Item
{
    public interface IItemCollector
    {
        public void CollectItem(ItemData data);
    }
}