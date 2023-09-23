using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Target
{
    public interface IEnemyTarget
    {
        public Vector3 Position { get; }

        public void TakeDamage(int value);
    }
}