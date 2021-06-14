using System;
using header;
using UnityEngine;
using UnityEngine.UI;

namespace body
{
    public class MiningResources : MonoBehaviour
    {
        [SerializeField] private Text perSecond;
        [SerializeField] private Image resourceImage;
        [SerializeField] private HeaderResources headerResources;

        private const float MiningTime = 1;
        private float _currentTime;
        private int _miningPerSecond;

        public void Reset()
        {
            _currentTime = MiningTime;
        }

        private void Start()
        {
            Reset();
        }

        private void Update()
        {
            _miningPerSecond = headerResources.GetPeasantCount() * Units.GetPeasantChangePerSecond()
                               + headerResources.GetWarriorCount() * Units.GetWarriorChangePerSecond();
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
            {
                _currentTime = MiningTime;
                headerResources.ChangeMoonshine(_miningPerSecond);
            }

            perSecond.text = _miningPerSecond.ToString();
            resourceImage.fillAmount = 1 - (_currentTime / MiningTime);
        }
    }
}