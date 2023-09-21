using GameCore.CodeBase.Gameplay.Player.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerModel
    {
        private readonly PlayerControllerPrefabData _instance;
        private readonly PlayerMovementStaticData _movementData;

        public PlayerModel(PlayerControllerPrefabData instance, PlayerMovementStaticData movementData)
        {
            _instance = instance;
            _movementData = movementData;
        }

        public GameObject GameObject => _instance.gameObject;

        public void MovePosition(Vector2 direction)
        {
            var offset = direction.normalized * (Time.fixedDeltaTime * _movementData.PositionVelocity);

            _instance.transform.position += new Vector3(offset.x, offset.y);
        }

        public void MoveRotation(Vector2 direction)
        {
            var oldScale = _instance.Skeleton.localScale;
            var xScale = direction.x < 0 ? -1 : 1;

            if (xScale != oldScale.x)
                _instance.Skeleton.localScale = new Vector3(xScale, oldScale.y, oldScale.z);
        }
    }
}