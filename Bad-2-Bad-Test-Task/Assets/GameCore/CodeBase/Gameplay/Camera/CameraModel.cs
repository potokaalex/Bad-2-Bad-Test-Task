using GameCore.CodeBase.Gameplay.Camera.Data;
using GameCore.CodeBase.Gameplay.Player;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Camera
{
    public class CameraModel
    {
        private readonly CameraPrefabData _instance;
        private readonly CameraMovementStaticData _movementData;
        private PlayerController _playerController;

        public CameraModel(CameraPrefabData instance, CameraMovementStaticData movementData)
        {
            _instance = instance;
            _movementData = movementData;
        }

        public void SetPlayerToFollow(PlayerController playerController) => _playerController = playerController;

        public void RemovePlayerToFollow() => _playerController = null;

        public void Update()
        {
            if (_playerController != null)
                FollowPlayer();
        }

        private void FollowPlayer()
        {
            var cameraPosition = _instance.transform.position;
            var playerPosition = _playerController.transform.position;
            var targetPosition = playerPosition + Vector3.forward * _movementData.Height;
            var interpolation = Time.fixedDeltaTime * _movementData.Smoothing;
            var newPosition = Vector3.Lerp(cameraPosition, targetPosition, interpolation);

            _instance.transform.position = newPosition;
        }
    }
}