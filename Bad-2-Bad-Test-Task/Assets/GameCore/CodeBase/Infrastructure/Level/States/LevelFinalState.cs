using GameCore.CodeBase.Infrastructure.Services.StateMachine.States;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelFinalState : StateBase, IEnterState
    {
        private LevelFactory _levelFactory;

        [Inject]
        private void Construct(LevelFactory levelFactory) => _levelFactory = levelFactory;

        public void Enter() => _levelFactory.CreateFinalUI();
    }
}