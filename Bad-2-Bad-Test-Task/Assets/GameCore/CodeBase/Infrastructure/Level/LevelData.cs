using System;
using GameCore.CodeBase.Infrastructure.Level.States;
using GameCore.CodeBase.Infrastructure.Level.UI;
using GameCore.CodeBase.Utilities.Scene;

namespace GameCore.CodeBase.Infrastructure.Level
{
    [Serializable]
    public class LevelData
    {
        public SpawnPoint PlayerSpawnPoint;
        public SpawnPoint[] EnemySpawnPoints;
        public LevelFinalUI FinalUIPrefab;
    }
}