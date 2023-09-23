using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Health.Data
{
    public class HealthData
    {
        private readonly HealthStaticData _staticData;
        private int _currentValue;

        public HealthData(HealthStaticData staticData)
        {
            _staticData = staticData;
            _currentValue = _staticData.InitialCount;
        }

        public void Change(int value) => _currentValue = Mathf.Clamp(_currentValue + value, 0, _staticData.MaxCount);

        public int Get() => _currentValue;
    }
}