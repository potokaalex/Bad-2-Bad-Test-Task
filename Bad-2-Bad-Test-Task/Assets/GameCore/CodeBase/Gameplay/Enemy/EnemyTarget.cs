using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyTarget : MonoBehaviour, IEnemyTarget
    {
        public Vector3 Position => transform.position;
    }
}