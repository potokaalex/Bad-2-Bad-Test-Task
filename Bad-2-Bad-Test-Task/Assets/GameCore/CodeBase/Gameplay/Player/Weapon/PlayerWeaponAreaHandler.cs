using GameCore.CodeBase.Gameplay.Enemy;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Weapon
{
    public class PlayerWeaponAreaHandler : MonoBehaviour
    {
        [SerializeField] private PlayerController _controller;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent<EnemyController>(out var enemy))
                _controller.SelectEnemy(enemy);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<EnemyController>(out var enemy))
                _controller.DeselectEnemy(enemy);
        }
    }
}