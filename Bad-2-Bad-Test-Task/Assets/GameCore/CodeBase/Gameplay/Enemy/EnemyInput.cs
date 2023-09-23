using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyInput : MonoBehaviour
    {
        [SerializeField] private EnemyController _controller;

        private void FixedUpdate() => _controller.UpdateModel(Time.fixedDeltaTime);
    }
}