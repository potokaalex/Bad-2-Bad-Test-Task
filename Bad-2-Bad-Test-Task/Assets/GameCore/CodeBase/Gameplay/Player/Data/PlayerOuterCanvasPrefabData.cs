using GameCore.CodeBase.Gameplay.Player.Input;
using GameCore.CodeBase.Gameplay.Player.InventoryUI;
using GameCore.CodeBase.Gameplay.Player.Weapon;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Data
{
    public class PlayerOuterCanvasPrefabData : MonoBehaviour
    {
        public PlayerInventoryUI InventoryUI;
        public PlayerWeaponShootButton ShootButton;
        public PlayerInputDevice[] InputDevices;
    }
}