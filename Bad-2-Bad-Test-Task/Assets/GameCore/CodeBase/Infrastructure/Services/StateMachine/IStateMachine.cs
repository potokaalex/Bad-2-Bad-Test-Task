namespace GameCore.CodeBase.Infrastructure.Services.StateMachine
{
    public interface IStateMachine
    {
        public void SwitchTo<StateType>()
            where StateType : IState;
    }
}