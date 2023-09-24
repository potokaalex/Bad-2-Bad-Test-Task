using GameCore.CodeBase.Gameplay.Player.Input;
using GameCore.CodeBase.Gameplay.Player.Inventory;
using GameCore.CodeBase.Gameplay.Player.Weapon;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Data.Static
{
    public class PlayerOuterCanvasPrefabData : MonoBehaviour
    {
        public PlayerInventoryUI InventoryUI;
        public PlayerWeaponShootButton ShootButton;
        public PlayerInputDevice[] InputDevices;
    }
}