using GameCore.CodeBase.Infrastructure.Services.StateMachine.States;

namespace GameCore.CodeBase.Infrastructure.Services.StateMachine.Factory
{
    public interface IStateFactory
    {
        public T Create<T>() where T : StateBase;
        
        public void Destroy<T>(T state) where T : StateBase;
    }
}