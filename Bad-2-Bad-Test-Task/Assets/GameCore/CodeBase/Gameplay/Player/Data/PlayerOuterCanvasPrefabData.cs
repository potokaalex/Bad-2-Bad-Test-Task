using GameCore.CodeBase.Gameplay.Player.Input;
using GameCore.CodeBase.Gameplay.Player.InventoryUI;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Data
{
    public class PlayerOuterCanvasPrefabData : MonoBehaviour
    {
        public PlayerInventoryUI InventoryUI;
        public PlayerInputDevice[] InputDevices;
    }
}