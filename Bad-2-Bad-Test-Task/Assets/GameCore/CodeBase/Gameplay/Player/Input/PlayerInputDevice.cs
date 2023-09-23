using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Input
{
    public abstract class PlayerInputDevice : MonoBehaviour
    {
        private protected readonly Vector2 InputVectorDefaultValue = default;
        private PlayerController _controller;
        private Vector2 _inputVector;

        public void Construct(PlayerController controller) => _controller = controller;

        private protected void SetInputVector(Vector2 newValue) => _inputVector = newValue;

        private void FixedUpdate()
        {
            if (_inputVector == InputVectorDefaultValue)
                return;

            _controller.Move(_inputVector);
            _controller.Rotate(_inputVector);
        }
    }
}