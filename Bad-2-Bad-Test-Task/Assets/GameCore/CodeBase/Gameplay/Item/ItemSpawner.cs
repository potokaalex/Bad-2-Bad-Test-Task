using GameCore.CodeBase.Gameplay.Item.Data;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Gameplay.Item
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnPoint _spawnPoint;
        [SerializeField] private ItemsType _type;
        [SerializeField] private int _count;
        [SerializeField] private float _spawnRateSeconds;

        private ItemFactory _itemFactory;
        private float _timeToSpawn;

        [Inject]
        private void Construct(ItemFactory itemFactory) => _itemFactory = itemFactory;

        private void FixedUpdate()
        {
            if (_timeToSpawn > 0)
            {
                _timeToSpawn -= Time.fixedDeltaTime;
                return;
            }

            Spawn();
            _timeToSpawn = _spawnRateSeconds;
        }

        private void Spawn()
        {
            var data = _itemFactory.CreateData(_type, _count);
            _itemFactory.CreateGameObject(_spawnPoint.Value, data);
        }
    }
}