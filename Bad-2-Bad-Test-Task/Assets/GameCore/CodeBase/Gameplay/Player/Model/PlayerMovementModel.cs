using GameCore.CodeBase.Gameplay.Player.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Model
{
    public class PlayerMovementModel
    {
        private readonly PlayerObjectPrefabData _instance;
        private readonly PlayerMovementStaticData _movementData;

        public PlayerMovementModel(PlayerObjectPrefabData instance, PlayerMovementStaticData movementData)
        {
            _instance = instance;
            _movementData = movementData;
        }

        public void MovePosition(Vector2 direction)
        {
            var velocity = Time.fixedDeltaTime * _movementData.PositionVelocity;
            var navMeshBugOffset = Vector2.right * 0.0001f;
            //A slight x offset to avoid BUG when strictly move along the y axis.

            var offset = direction.normalized * velocity + navMeshBugOffset;

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