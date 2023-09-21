using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerController
    {
        private readonly PlayerModel _model;

        public PlayerController(PlayerModel model) => _model = model;

        public GameObject GameObject => _model.GameObject;

        public void Move(Vector2 direction) => _model.MovePosition(direction);

        public void Rotate(Vector2 direction) => _model.MoveRotation(direction);
    }
}