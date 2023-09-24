using GameCore.CodeBase.Gameplay.Player;

namespace GameCore.CodeBase.Gameplay.Camera
{
    public class CameraController
    {
        private readonly CameraModel _model;

        public CameraController(CameraModel model) => _model = model;

        public void SetPlayerToFollow(PlayerController player) => _model.SetPlayerToFollow(player);

        public void RemovePlayerToFollow() => _model.RemovePlayerToFollow();

        public void UpdateModel() => _model.Update();
    }
}