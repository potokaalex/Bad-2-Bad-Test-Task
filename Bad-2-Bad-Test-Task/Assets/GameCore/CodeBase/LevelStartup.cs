using GameCore.CodeBase.Gameplay;
using GameCore.CodeBase.Gameplay.Camera;
using GameCore.CodeBase.Gameplay.Camera.Data;
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

        private void Start()
        {
            var playerFactory = new PlayerFactory(PlayerStaticData);
            playerFactory.CreatePlayer(PlayerSpawnPoint);

            var cameraFactory = new CameraFactory(CameraStaticData);
            cameraFactory.Create(playerFactory.CurrentPlayer);
        }
    }
}