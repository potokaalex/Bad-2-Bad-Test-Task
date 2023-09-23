using GameCore.CodeBase.Infrastructure.Level.States;
using GameCore.CodeBase.Infrastructure.Services.StateMachine;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class LevelStartup : MonoBehaviour
    {
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IStateMachine stateMachine) => _stateMachine = stateMachine;

        private void Start() => _stateMachine.SwitchTo<LevelStartupState>();
    }
}