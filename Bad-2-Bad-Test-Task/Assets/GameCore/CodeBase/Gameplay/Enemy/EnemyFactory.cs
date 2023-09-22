using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyFactory
    {
        private readonly EnemyStaticData _staticData;

        public EnemyFactory(EnemyStaticData staticData) => _staticData = staticData;

        public void Create()
        {
            var instance = Object.Instantiate(_staticData.Prefab);
            var model = new EnemyModel(instance);
            var controller = new EnemyController(model);

            instance.TargetHandler.Construct(controller);
            instance.Input.Construct(controller);
        }
    }
}