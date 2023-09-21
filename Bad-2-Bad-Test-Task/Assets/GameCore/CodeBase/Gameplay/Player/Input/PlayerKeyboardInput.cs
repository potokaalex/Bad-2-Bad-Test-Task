using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Input
{
    public class PlayerKeyboardInput : PlayerInputDevice
    {
        private void Update()
        {
            var inputVector = Vector2.zero;

            if (UnityEngine.Input.GetKey(KeyCode.W))
                inputVector += Vector2.up;
            if (UnityEngine.Input.GetKey(KeyCode.A))
                inputVector += Vector2.left;
            if (UnityEngine.Input.GetKey(KeyCode.S))
                inputVector += Vector2.down;
            if (UnityEngine.Input.GetKey(KeyCode.D))
                inputVector += Vector2.right;

            SetInputVector(inputVector);
        }
    }
}