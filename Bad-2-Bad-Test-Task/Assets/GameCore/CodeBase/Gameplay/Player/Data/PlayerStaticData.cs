using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Data
{
    [CreateAssetMenu(menuName = "Configurations/Player", fileName = "PlayerConfig", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        public PlayerObjectPrefabData ObjectPrefab;
        public PlayerOuterCanvasPrefabData OuterCanvasPrefab;
        public PlayerMovementStaticData MovementData;
        public PlayerWeaponStaticData WeaponData;
        public int InventorySize;
    }
}