using GameCore.CodeBase.Gameplay.Health.Data;
using GameCore.CodeBase.Gameplay.Player.Data;
using GameCore.CodeBase.Gameplay.Player.Data.Static;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerUI
    {
        private readonly PlayerInnerCanvasData _innerCanvas;

        public PlayerUI(PlayerInnerCanvasData innerCanvas, PlayerOuterCanvasPrefabData outerCanvas,
            PlayerController controller, HealthStaticData healthStaticData)
        {
            _innerCanvas = innerCanvas;

            innerCanvas.HealthSlider.Construct(healthStaticData.MaxCount, healthStaticData.InitialCount);
            outerCanvas.InventoryUI.Construct(controller);
            outerCanvas.ShootButton.Construct(controller);

            foreach (var inputDevice in outerCanvas.InputDevices)
                inputDevice.Construct(controller);
        }

        public void SetHealth(int value) => _innerCanvas.HealthSlider.SetHealth(value);
    }
}