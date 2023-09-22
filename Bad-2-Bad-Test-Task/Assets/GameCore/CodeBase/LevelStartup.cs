using GameCore.CodeBase.Gameplay;
using GameCore.CodeBase.Gameplay.Camera;
using GameCore.CodeBase.Gameplay.Camera.Data;
using GameCore.CodeBase.Gameplay.Enemy;
using GameCore.CodeBase.Gameplay.Enemy.Data;
using GameCore.CodeBase.Gameplay.Item;
using GameCore.CodeBase.Gameplay.Item.Data;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Gameplay.Player.Data;
using UnityEngine;

namespace GameCore.CodeBase
{
    public class LevelStartup : MonoBehaviour
    {
        public PlayerStaticData PlayerStaticData;
        public SpawnPoint PlayerSpawnPoint;
        public CameraStaticData CameraStaticData;
        public EnemyStaticData EnemyStaticData;
        public SpawnPoint[] EnemySpawnPoints;
        public ItemsStaticData ItemsStaticData;
        public ItemSpawner ItemSpawner;
        
        private void Start()
        {
            var playerFactory = new PlayerFactory(PlayerStaticData);
            playerFactory.CreatePlayer(PlayerSpawnPoint);

            var cameraFactory = new CameraFactory(CameraStaticData);
            cameraFactory.Create(PlayerSpawnPoint, playerFactory.CurrentPlayer);

            var enemyFactory = new EnemyFactory(EnemyStaticData);
            enemyFactory.Create(EnemySpawnPoints);

            var itemFactory = new ItemFactory(ItemsStaticData);
            ItemSpawner.Construct(itemFactory);
        }
    }
}