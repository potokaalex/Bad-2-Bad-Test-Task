using GameCore.CodeBase.Gameplay.Camera.Data;
using GameCore.CodeBase.Gameplay.Player;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Camera
{
    public class CameraModel
    {
        private readonly CameraPrefabData _instance;
        private readonly CameraMovementStaticData _movementData;
        private readonly PlayerController _playerController;

        public CameraModel(CameraPrefabData instance, CameraMovementStaticData movementData,
            PlayerController playerController)
        {
            _instance = instance;
            _movementData = movementData;
            _playerController = playerController;
        }

        public void FollowPlayer()
        {
            var cameraPosition = _instance.transform.position;
            var playerPosition = _playerController.GameObject.transform.position;
            var targetPosition = playerPosition + Vector3.forward * _movementData.Height;
            var interpolation = Time.fixedDeltaTime * _movementData.Smoothing;
            var newPosition = Vector3.Lerp(cameraPosition, targetPosition, interpolation);

            _instance.transform.position = newPosition;
        }
    }
}