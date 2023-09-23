using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Data
{
    public class PlayerObjectPrefabData : MonoBehaviour
    {
        public Transform Skeleton;
        public PlayerItemCollector ItemCollector;
        public PlayerWeaponAreaHandler WeaponAreaHandler;
        public PlayerInnerCanvasData InnerCanvas;
        public PlayerController Controller;
    }
}