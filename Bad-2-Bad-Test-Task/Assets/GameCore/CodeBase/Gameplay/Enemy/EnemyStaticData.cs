using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    [CreateAssetMenu(menuName = "Configurations/Enemy", fileName = "EnemyConfig", order = 0)]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyPrefabData Prefab;
    }
}