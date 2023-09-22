using System;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Item.Data
{
    [Serializable]
    public class ItemStaticData
    {
        public ItemPrefabData Prefab;
        public Sprite Icon;
        public int MaxCountInStack;
    }
}