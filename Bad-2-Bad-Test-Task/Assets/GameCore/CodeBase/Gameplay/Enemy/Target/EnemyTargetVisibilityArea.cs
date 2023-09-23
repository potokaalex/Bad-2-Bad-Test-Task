using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Target
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyTargetVisibilityArea : MonoBehaviour
    {
        [SerializeField] private EnemyController _controller;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent<IEnemyTarget>(out var target))
                _controller.SetTargetToFollow(target);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<IEnemyTarget>(out _))
                _controller.RemoveTargetToFollow();
        }
    }
}