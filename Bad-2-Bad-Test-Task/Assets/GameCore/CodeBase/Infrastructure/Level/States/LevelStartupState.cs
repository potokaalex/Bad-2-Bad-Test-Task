using GameCore.CodeBase.Gameplay.Camera;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Infrastructure.Services.StateMachine;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelStartupState : IState
    {
        private readonly LevelSceneData _sceneData;
        private readonly PlayerFactory _playerFactory;
        private readonly CameraFactory _cameraFactory;
        private readonly EnemyFactory _enemyFactory;
        private readonly IStateMachine _stateMachine;

        private LevelStartupState(LevelSceneData sceneData, PlayerFactory playerFactory, CameraFactory cameraFactory,
            EnemyFactory enemyFactory, IStateMachine stateMachine)
        {
            _sceneData = sceneData;
            _playerFactory = playerFactory;
            _cameraFactory = cameraFactory;
            _enemyFactory = enemyFactory;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _playerFactory.CreatePlayer(_sceneData.PlayerSpawnPoint.Value);
            _cameraFactory.Create(_sceneData.PlayerSpawnPoint.Value, _playerFactory.CurrentPlayer);
            _enemyFactory.Create(_sceneData.EnemySpawnPoints);
            _stateMachine.SwitchTo<LevelGameplayState>();
        }
    }
}