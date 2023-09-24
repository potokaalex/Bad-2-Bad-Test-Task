using GameCore.CodeBase.Infrastructure.Services.StateMachine;
using UnityEngine;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class LevelFactory
    {
        private readonly LevelData _levelData;
        private readonly IStateMachine _stateMachine;

        public LevelFactory(LevelData levelData, IStateMachine stateMachine)
        {
            _levelData = levelData;
            _stateMachine = stateMachine;
        }

        public void CreateFinalUI()
        {
            var instantiate = Object.Instantiate(_levelData.FinalUIPrefab);
            instantiate.Construct(_stateMachine);
        }
    }
}