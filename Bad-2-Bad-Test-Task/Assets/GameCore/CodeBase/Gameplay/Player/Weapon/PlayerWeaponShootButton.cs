using GameCore.CodeBase.Utilities.UI;

namespace GameCore.CodeBase.Gameplay.Player.Weapon
{
    public class PlayerWeaponShootButton : ButtonBase
    {
        private PlayerController _controller;

        public void Construct(PlayerController controller) => _controller = controller;

        private protected override void OnClick() => _controller.Shoot();
    }
}