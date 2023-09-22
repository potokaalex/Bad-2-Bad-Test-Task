using System;
using GameCore.CodeBase.Gameplay.Item.Data;
using GameCore.CodeBase.Gameplay.SpawnPoint;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace GameCore.CodeBase.Gameplay.Item
{
    public class ItemFactory
    {
        private readonly ItemsStaticData _staticData;

        public ItemFactory(ItemsStaticData staticData) => _staticData = staticData;

        public void CreateRandom(ISpawnPoint spawnPoint)
        {
            var type = (ItemsType)Random.Range(0, ItemsStaticData.Count);
            Create(spawnPoint, type);
        }

        public void Create(ISpawnPoint spawnPoint, ItemsType type)
        {
            switch (type)
            {
                case ItemsType.Ammunition:
                    Create(_staticData.Ammunition, spawnPoint);
                    break;
                case ItemsType.ZombieHead:
                    Create(_staticData.ZombieHead, spawnPoint);
                    break;
                case ItemsType.ZombieArm:
                    Create(_staticData.ZombieArm, spawnPoint);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void Create(ItemStaticData data, ISpawnPoint spawnPoint)
        {
            var instance = Object.Instantiate(data.Prefab, spawnPoint.Value, Quaternion.identity);
        }
    }
}