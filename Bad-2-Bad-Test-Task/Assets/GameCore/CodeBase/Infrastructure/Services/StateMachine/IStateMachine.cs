using GameCore.CodeBase.Infrastructure.Services.StateMachine.States;

namespace GameCore.CodeBase.Infrastructure.Services.StateMachine
{
    public interface IStateMachine
    {
        public void SwitchTo<T>() where T : StateBase;
    }
}