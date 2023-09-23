using GameCore.CodeBase.Gameplay.Health.Data;
using GameCore.CodeBase.Gameplay.Health.UI;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyUI : MonoBehaviour
    {
        [SerializeField] private HealthSlider _slider;

        public void SetHealth(int value) => _slider.SetHealth(value);

        public void Construct(HealthStaticData healthStaticData) =>
            _slider.Construct(healthStaticData.MaxCount, healthStaticData.InitialCount);
    }
}