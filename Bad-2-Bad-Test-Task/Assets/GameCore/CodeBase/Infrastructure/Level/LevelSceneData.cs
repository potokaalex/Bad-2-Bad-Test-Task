using System;
using GameCore.CodeBase.Utilities.Scene;

namespace GameCore.CodeBase.Infrastructure.Level
{
    [Serializable]
    public class LevelSceneData
    {
        public SpawnPoint PlayerSpawnPoint;
        public SpawnPoint[] EnemySpawnPoints;
    }
}