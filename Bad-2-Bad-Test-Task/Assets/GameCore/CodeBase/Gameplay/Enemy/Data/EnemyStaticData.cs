using GameCore.CodeBase.Gameplay.Health.Data;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Data
{
    [CreateAssetMenu(menuName = "Configurations/Enemy", fileName = "EnemyConfig", order = 0)]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyPrefabData Prefab;
        public int MaxEnemyCount;
        public HealthStaticData HealthData;
        public WeaponStaticData WeaponData;
    }
}