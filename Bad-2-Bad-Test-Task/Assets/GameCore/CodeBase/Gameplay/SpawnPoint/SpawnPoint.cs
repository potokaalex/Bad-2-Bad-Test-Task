using UnityEngine;

namespace GameCore.CodeBase.Gameplay.SpawnPoint
{
    public class SpawnPoint : MonoBehaviour, ISpawnPoint
    {
        public Vector3 Value => transform.position;
    }
}