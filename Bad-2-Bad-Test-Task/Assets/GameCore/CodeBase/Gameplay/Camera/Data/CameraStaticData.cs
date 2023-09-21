using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Camera.Data
{
    [CreateAssetMenu(menuName = "Configurations/Camera", fileName = "CameraConfig", order = 0)]
    public class CameraStaticData : ScriptableObject
    {
        public CameraPrefabData CameraPrefab;
        public CameraMovementStaticData MovementData;
    }
}