using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Target
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyTargetHandler : MonoBehaviour
    {
        private EnemyController _controller;

        public void Construct(EnemyController controller) => _controller = controller;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent<IEnemyTarget>(out var target))
                _controller.Follow(target);
        }
    }
}