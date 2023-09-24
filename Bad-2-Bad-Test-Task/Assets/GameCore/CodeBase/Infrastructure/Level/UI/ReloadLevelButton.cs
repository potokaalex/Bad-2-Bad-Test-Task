using GameCore.CodeBase.Infrastructure.Level.States;
using GameCore.CodeBase.Infrastructure.Services.StateMachine;
using GameCore.CodeBase.Utilities.UI;

namespace GameCore.CodeBase.Infrastructure.Level.UI
{
    public class ReloadLevelButton : ButtonBase
    {
        private IStateMachine _stateMachine;

        public void Construct(IStateMachine stateMachine) => _stateMachine = stateMachine;

        private protected override void OnClick() => _stateMachine.SwitchTo<LevelLoadingState>();
    }
}