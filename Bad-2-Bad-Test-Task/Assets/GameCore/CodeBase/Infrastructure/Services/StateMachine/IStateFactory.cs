namespace GameCore.CodeBase.Infrastructure.Services.StateMachine
{
    public interface IStateFactory
    {
        public StateType Create<StateType>() where StateType : IState;
    }
}
