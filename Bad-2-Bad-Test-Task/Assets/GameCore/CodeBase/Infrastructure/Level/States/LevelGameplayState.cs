using GameCore.CodeBase.Gameplay.Camera;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Infrastructure.Services.StateMachine;
using GameCore.CodeBase.Infrastructure.Services.StateMachine.States;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelGameplayState : StateBase, IEnterState, IExitState
    {
        private IStateMachine _stateMachine;
        private EnemyFactory _enemyFactory;
        private PlayerFactory _playerFactory;
        private CameraFactory _cameraFactory;

        [Inject]
        private void Construct(IStateMachine stateMachine, EnemyFactory enemyFactory, PlayerFactory playerFactory,
            CameraFactory cameraFactory)
        {
            _enemyFactory = enemyFactory;
            _playerFactory = playerFactory;
            _stateMachine = stateMachine;
            _cameraFactory = cameraFactory;
        }

        public void Enter() => _cameraFactory.CurrentCamera.SetPlayerToFollow(_playerFactory.CurrentPlayer);

        private void FixedUpdate()
        {
            if (_enemyFactory.EnemiesCount == 0)
                _stateMachine.SwitchTo<LevelFinalState>();
            else if (_playerFactory.CurrentPlayer == null)
            {
                _cameraFactory.CurrentCamera.RemovePlayerToFollow();
                _stateMachine.SwitchTo<LevelFinalState>();
            }
        }

        public void Exit()
        {
        }
    }
}