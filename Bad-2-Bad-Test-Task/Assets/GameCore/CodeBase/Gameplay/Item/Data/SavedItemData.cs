using System;

namespace GameCore.CodeBase.Gameplay.Item.Data
{
    [Serializable]
    public class SavedItemData
    {
        public ItemsType Type;
        public int CurrentCount;
    }
}