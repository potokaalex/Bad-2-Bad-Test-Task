using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Data
{
    [CreateAssetMenu(menuName = "Configurations/Enemy", fileName = "EnemyConfig", order = 0)]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyPrefabData Prefab;
        public int MaxEnemyCount;
    }
}