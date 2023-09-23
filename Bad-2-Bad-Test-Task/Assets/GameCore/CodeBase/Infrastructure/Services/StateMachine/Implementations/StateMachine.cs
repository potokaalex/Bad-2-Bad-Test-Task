using System;
using System.Collections.Generic;

namespace GameCore.CodeBase.Infrastructure.Services.StateMachine.Implementations
{
    public class StateMachine : IStateMachine
    {
        private readonly IStateFactory _factory;
        private readonly Dictionary<Type, IState> _states = new();
        private IState _currentState;

        public StateMachine(IStateFactory factory) => _factory = factory;

        public void SwitchTo<StateType>() where StateType : IState
        {
            _currentState?.Exit();
            _currentState = GetOrCreateState<StateType>();
            _currentState?.Enter();
        }

        private IState GetOrCreateState<StateType>() where StateType : IState
        {
            var stateType = typeof(StateType);

            if (_states.TryGetValue(stateType, out var state))
                return state;

            var newState = _factory.Create<StateType>();
            _states.Add(stateType, newState);

            return newState;
        }
    }
}