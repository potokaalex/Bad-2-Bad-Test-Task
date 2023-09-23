using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Item.Data.Static
{
    [CreateAssetMenu(menuName = "Configurations/Items", fileName = "ItemsConfig", order = 0)]
    public class ItemsStaticData : ScriptableObject
    {
        public const int Count = 3;

        public ItemPrefabData Prefab;
        public ItemStaticData Ammunition;
        public ItemStaticData ZombieHead;
        public ItemStaticData ZombieArm;
    }
}