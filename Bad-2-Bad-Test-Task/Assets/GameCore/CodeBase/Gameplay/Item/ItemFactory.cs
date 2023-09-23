using System;
using GameCore.CodeBase.Gameplay.Inventory;
using GameCore.CodeBase.Gameplay.Item.Data;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace GameCore.CodeBase.Gameplay.Item
{
    public class ItemFactory
    {
        private readonly ItemsStaticData _staticData;

        public ItemFactory(ItemsStaticData staticData) => _staticData = staticData;

        public ItemData CreateData(ItemsType type, int count)
        {
            var data = CreateRawData(type);

            data.Type = type;
            data.CurrentCount = count;

            return data;
        }

        public void CreateGameObjectRandom(ISpawnPoint spawnPoint, int count)
        {
            var type = (ItemsType)Random.Range(0, ItemsStaticData.Count);
            var data = CreateData(type, count);

            CreateGameObject(spawnPoint, data);
        }

        public void CreateGameObject(ISpawnPoint spawnPoint, ItemData data)
        {
            var instance = Object.Instantiate(_staticData.Prefab, spawnPoint.Value, Quaternion.identity);

            instance.CollisionHandler.Construct(this, data, instance);
            instance.SpriteRenderer.sprite = data.Static.Icon;
        }

        public void Destroy(ItemPrefabData prefabInstance) => Object.Destroy(prefabInstance.gameObject);

        private ItemData CreateRawData(ItemsType type)
        {
            return type switch
            {
                ItemsType.Ammunition => new ItemData { Static = _staticData.Ammunition },
                ItemsType.ZombieHead => new ItemData { Static = _staticData.ZombieHead },
                ItemsType.ZombieArm => new ItemData { Static = _staticData.ZombieArm },
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}