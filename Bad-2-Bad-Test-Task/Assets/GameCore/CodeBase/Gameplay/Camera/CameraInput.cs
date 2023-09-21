using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Camera
{
    public class CameraInput : MonoBehaviour
    {
        private CameraController _controller;

        public void Construct(CameraController controller) => _controller = controller;

        private void FixedUpdate() => _controller.FollowPlayer();
    }
}