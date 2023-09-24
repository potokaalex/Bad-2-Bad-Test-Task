using GameCore.CodeBase.Gameplay.Player.Data;
using GameCore.CodeBase.Infrastructure.Services.ProgressSaveLoader;
using GameCore.CodeBase.Infrastructure.Services.StateMachine.States;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelFinalState : StateBase, IEnterState, IExitState
    {
        private LevelFactory _levelFactory;
        private IProgressSaveLoader _progressSaveLoader;

        [Inject]
        private void Construct(LevelFactory levelFactory, IProgressSaveLoader progressSaveLoader)
        {
            _levelFactory = levelFactory;
            _progressSaveLoader = progressSaveLoader;
        }

        public void Enter() => _levelFactory.CreateFinalUI();

        public void Exit()
        {
            _progressSaveLoader.Save<PlayerProgressData>();
            _progressSaveLoader.ClearWatchers();
        }
    }
}