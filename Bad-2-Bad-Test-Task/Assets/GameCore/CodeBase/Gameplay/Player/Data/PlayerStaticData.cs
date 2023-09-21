using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Data
{
    [CreateAssetMenu(menuName = "Configurations/Player", fileName = "PlayerConfig", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        public PlayerControllerPrefabData ControllerPrefab;
        public PlayerUIPrefabData[] UIPrefabs;
        public PlayerMovementStaticData MovementData;
    }
}