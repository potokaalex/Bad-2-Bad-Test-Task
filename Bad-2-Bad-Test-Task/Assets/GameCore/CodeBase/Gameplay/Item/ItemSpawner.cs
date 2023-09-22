using GameCore.CodeBase.Gameplay.Item.Data;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Gameplay.Item
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnPoint.SpawnPoint _spawnPoint;
        [SerializeField] private ItemsType _type;
        [SerializeField] private float _spawnRateSeconds;

        private ItemFactory _itemFactory;
        private float _timeToSpawn;

        [Inject]
        private void Construct(ItemFactory itemFactory) => _itemFactory = itemFactory;

        private void FixedUpdate()
        {
            if (_timeToSpawn <= 0)
            {
                _itemFactory.Create(_spawnPoint, _type);
                _timeToSpawn = _spawnRateSeconds;
            }

            _timeToSpawn -= Time.fixedDeltaTime;
        }
    }
}