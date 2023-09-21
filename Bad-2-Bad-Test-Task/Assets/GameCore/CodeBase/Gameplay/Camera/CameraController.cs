namespace GameCore.CodeBase.Gameplay.Camera
{
    public class CameraController
    {
        private readonly CameraModel _model;

        public CameraController(CameraModel model) => _model = model;

        public void FollowPlayer() => _model.FollowPlayer();
    }
}