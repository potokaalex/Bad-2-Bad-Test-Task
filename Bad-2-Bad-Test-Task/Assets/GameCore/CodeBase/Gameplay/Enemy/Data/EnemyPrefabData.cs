using GameCore.CodeBase.Gameplay.Enemy.Target;
using UnityEngine;
using UnityEngine.AI;

namespace GameCore.CodeBase.Gameplay.Enemy.Data
{
    public class EnemyPrefabData : MonoBehaviour
    {
        public EnemyTargetHandler TargetHandler;
        public NavMeshAgent Agent;
    }
}