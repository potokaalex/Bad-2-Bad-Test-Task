using GameCore.CodeBase.Gameplay.Enemy.Target;
using UnityEngine;
using UnityEngine.AI;

namespace GameCore.CodeBase.Gameplay.Enemy.Data
{
    public class EnemyPrefabData : MonoBehaviour
    {
        public EnemyTargetVisibilityArea TargetVisibilityArea;
        public EnemyTargetAttackArea TargetAttackArea;
        public EnemyController Controller;
        public NavMeshAgent Agent;
        public Transform Skeleton;
        public EnemyUI UI;
    }
}