using UnityEngine;
using UnityEngine.AI;

namespace GameCore.CodeBase.Gameplay.Enemy.Data
{
    public class EnemyPrefabData : MonoBehaviour
    {
        public EnemyController Controller;
        public NavMeshAgent Agent;
        public Transform Skeleton;
        public EnemyUI UI;
    }
}