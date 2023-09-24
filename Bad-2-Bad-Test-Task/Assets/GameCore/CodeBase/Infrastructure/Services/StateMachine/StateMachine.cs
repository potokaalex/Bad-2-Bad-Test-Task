using GameCore.CodeBase.Infrastructure.Services.StateMachine.Factory;
using GameCore.CodeBase.Infrastructure.Services.StateMachine.States;

namespace GameCore.CodeBase.Infrastructure.Services.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly IStateFactory _factory;
        private StateBase _currentState;

        public StateMachine(IStateFactory factory) => _factory = factory;

        public void SwitchTo<T>() where T : StateBase
        {
            if (_currentState is IExitState exitState)
                exitState.Exit();

            _factory.Destroy(_currentState);
            _currentState = _factory.Create<T>();

            if (_currentState is IEnterState enterState)
                enterState.Enter();
        }
    }
}