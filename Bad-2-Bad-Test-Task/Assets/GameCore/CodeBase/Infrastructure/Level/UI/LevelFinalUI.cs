using GameCore.CodeBase.Infrastructure.Services.StateMachine;
using UnityEngine;

namespace GameCore.CodeBase.Infrastructure.Level.UI
{
    public class LevelFinalUI : MonoBehaviour
    {
        [SerializeField] private ReloadLevelButton _reloadLevelButton;

        public void Construct(IStateMachine stateMachine) => _reloadLevelButton.Construct(stateMachine);
    }
}