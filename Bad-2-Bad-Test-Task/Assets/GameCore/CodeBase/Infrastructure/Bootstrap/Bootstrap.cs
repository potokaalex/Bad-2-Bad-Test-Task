using GameCore.CodeBase.Infrastructure.Level.States;
using GameCore.CodeBase.Infrastructure.Services.StateMachine;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine) => _stateMachine = stateMachine;
        
        private void Start() => _stateMachine.SwitchTo<LevelLoadingState>();
    }
}