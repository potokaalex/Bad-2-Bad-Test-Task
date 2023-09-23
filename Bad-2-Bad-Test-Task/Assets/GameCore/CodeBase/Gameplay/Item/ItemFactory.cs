using System;
using GameCore.CodeBase.Gameplay.Inventory;
using GameCore.CodeBase.Gameplay.Item.Data;
using GameCore.CodeBase.Gameplay.Item.Data.Static;
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
            var staticData = GetStaticData(type);

            return new ItemData
            {
                Icon = staticData.Icon,
                Type = type,
                MaxCount = staticData.MaxCount,
                CurrentCount = count
            };
        }

        public void CreateGameObjectRandom(Vector3 position)
        {
            var type = (ItemsType)Random.Range(0, ItemsStaticData.Count);
            var data = CreateData(type, 0);

            data.CurrentCount = Random.Range(1, data.MaxCount);

            CreateGameObject(position, data);
        }

        public void CreateGameObject(Vector3 position, ItemData data)
        {
            var instance = Object.Instantiate(_staticData.Prefab, position, Quaternion.identity);

            instance.CollisionHandler.Construct(this, data, instance);
            instance.SpriteRenderer.sprite = data.Icon;
        }

        public void Destroy(ItemPrefabData prefabInstance) => Object.Destroy(prefabInstance.gameObject);

        private ItemStaticData GetStaticData(ItemsType type)
        {
            return type switch
            {
                ItemsType.Ammunition => _staticData.Ammunition,
                ItemsType.ZombieHead => _staticData.ZombieHead,
                ItemsType.ZombieArm => _staticData.ZombieArm,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}