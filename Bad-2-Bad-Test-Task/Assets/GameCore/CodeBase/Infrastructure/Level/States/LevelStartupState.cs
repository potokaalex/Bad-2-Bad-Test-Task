using GameCore.CodeBase.Gameplay.Camera;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Infrastructure.Services.StateMachine;
using GameCore.CodeBase.Infrastructure.Services.StateMachine.States;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelStartupState : StateBase, IEnterState
    {
        private LevelData _levelData;
        private PlayerFactory _playerFactory;
        private CameraFactory _cameraFactory;
        private EnemyFactory _enemyFactory;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(LevelData levelData, PlayerFactory playerFactory, CameraFactory cameraFactory,
            EnemyFactory enemyFactory, IStateMachine stateMachine)
        {
            _levelData = levelData;
            _playerFactory = playerFactory;
            _cameraFactory = cameraFactory;
            _enemyFactory = enemyFactory;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _playerFactory.CreatePlayer(_levelData.PlayerSpawnPoint.Value);
            _cameraFactory.Create(_levelData.PlayerSpawnPoint.Value);
            _enemyFactory.Create(_levelData.EnemySpawnPoints);
            _stateMachine.SwitchTo<LevelGameplayState>();
        }
    }
}