using UnityEngine;

namespace GameCore.CodeBase.Infrastructure
{
    [CreateAssetMenu(menuName = "Configurations/Scenes", fileName = "ScenesConfig", order = 0)]
    public class ScenesStaticData : ScriptableObject
    {
        public string LevelSceneName;
    }
}