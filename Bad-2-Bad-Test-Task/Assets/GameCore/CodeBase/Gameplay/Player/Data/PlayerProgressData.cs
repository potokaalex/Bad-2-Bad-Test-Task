using System;
using GameCore.CodeBase.Gameplay.Item.Data;
using GameCore.CodeBase.Infrastructure.Services.ProgressSaveLoader;

namespace GameCore.CodeBase.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerProgressData : IProgressData
    {
        public SavedItemData[] InventoryItems;
    }
}