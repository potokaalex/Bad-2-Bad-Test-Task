using GameCore.CodeBase.Gameplay.Camera.Data;
using GameCore.CodeBase.Gameplay.Player;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Camera
{
    public class CameraFactory
    {
        private readonly CameraStaticData _staticData;

        public CameraFactory(CameraStaticData staticData) => _staticData = staticData;

        public CameraController CurrentCamera { get; private set; }

        public void Create(Vector3 position)
        {
            var instance = Object.Instantiate(_staticData.CameraPrefab, position, Quaternion.identity);
            var model = new CameraModel(instance, _staticData.MovementData);
            var controller = new CameraController(model);

            instance.Input.Construct(controller);

            CurrentCamera = controller;
        }
    }
}