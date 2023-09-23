using GameCore.CodeBase.Gameplay.Player.Input;
using GameCore.CodeBase.Gameplay.Player.Inventory;
using GameCore.CodeBase.Gameplay.Player.Weapon;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Data.UI
{
    public class PlayerOuterCanvasPrefabData : MonoBehaviour
    {
        public PlayerInventoryUI InventoryUI;
        public PlayerWeaponShootButton ShootButton;
        public PlayerInputDevice[] InputDevices;
    }
}