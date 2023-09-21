using AYellowpaper;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Data
{
    public class PlayerUIPrefabData : MonoBehaviour
    {
        [RequireInterface(typeof(IPlayerUIElement))]
        public MonoBehaviour[] UIElements;
    }
}