using GameCore.CodeBase.Infrastructure.Services.StateMachine.States;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Services.StateMachine.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) => _container = container;

        public T Create<T>() where T : StateBase
        {
            var state = _container.InstantiateComponentOnNewGameObject<T>();

            _container.Inject(state);

            return state;
        }

        public void Destroy<T>(T state) where T : StateBase => Object.Destroy(state);
    }
}