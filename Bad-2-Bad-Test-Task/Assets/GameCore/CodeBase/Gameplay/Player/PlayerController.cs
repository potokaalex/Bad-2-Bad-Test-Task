using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerController
    {
        private readonly PlayerModel _model;

        public PlayerController(PlayerModel model) => _model = model;

        public GameObject GameObject => _model.GameObject;

        public void Move(Vector2 inputVector) => _model.MovePosition(inputVector);

        public void Rotate(Vector2 inputVector) => _model.MoveRotation(inputVector);
    }
}