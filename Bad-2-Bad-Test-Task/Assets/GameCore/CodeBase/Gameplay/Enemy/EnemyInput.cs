using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyInput : MonoBehaviour
    {
        private EnemyController _controller;

        public void Construct(EnemyController controller) => _controller = controller;

        private void Start()
        {
            //_controller.Folow();
        }

        private void OnTriggerEnter(Collider other)
        {
        }
    }
}