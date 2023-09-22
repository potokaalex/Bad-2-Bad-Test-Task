using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyTargetHandler : MonoBehaviour
    {
        private EnemyController _controller;

        public void Construct(EnemyController controller) => _controller = controller;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IEnemyTarget>(out var target))
                _controller.Follow(target);
        }
    }
}