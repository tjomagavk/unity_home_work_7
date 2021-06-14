using System;
using body;
using header;
using prefabs;
using UnityEngine;

namespace body
{
    public class Units : MonoBehaviour
    {
        [SerializeField] private Unit peasant;
        [SerializeField] private Unit warrior;
        [SerializeField] private HeaderResources headerResources;
        [SerializeField] private MiningResources miningResources;

        private const int PeasantPrice = 10;
        private const int WarriorPrice = 20;

        private const float PeasantHuntingTime = 1f;
        private const float WarriorHuntingTime = 3f;

        private const int PeasantChangePerSecond = 2;
        private const int WarriorChangePerSecond = -5;

        private float _peasantHuntingDeltaTime;
        private float _warriorHuntingDeltaTime;

        private bool _peasantHuntingProcess;
        private bool _warriorHuntingProcess;

        // Start is called before the first frame update
        void Start()
        {
            peasant.GetAddButton().onClick.AddListener(PeasantOnClick);
            peasant.SetPrice(PeasantPrice);
            warrior.GetAddButton().onClick.AddListener(WarriorOnClick);
            warrior.SetPrice(WarriorPrice);
        }

        private void Update()
        {
            int moonshineCount = headerResources.GetMoonshineCount();
            peasant.GetAddButton().interactable = moonshineCount >= peasant.GetPrice() && !_peasantHuntingProcess;
            warrior.GetAddButton().interactable = moonshineCount >= warrior.GetPrice() && !_warriorHuntingProcess;

            if (_peasantHuntingProcess)
            {
                _peasantHuntingDeltaTime -= Time.deltaTime;
                peasant.SetFillAmount(_peasantHuntingDeltaTime / PeasantHuntingTime);
                if (_peasantHuntingDeltaTime <= 0)
                {
                    _peasantHuntingProcess = false;
                    headerResources.ChangePeasant(1);
                    peasant.SetFillAmount(1);
                }
            }

            if (_warriorHuntingProcess)
            {
                _warriorHuntingDeltaTime -= Time.deltaTime;
                warrior.SetFillAmount(_warriorHuntingDeltaTime / WarriorHuntingTime);
                if (_warriorHuntingDeltaTime <= 0)
                {
                    _warriorHuntingProcess = false;
                    headerResources.ChangeWarrior(1);
                    warrior.SetFillAmount(1);
                }
            }
        }

        public static int GetPeasantChangePerSecond()
        {
            return PeasantChangePerSecond;
        }

        public static int GetWarriorChangePerSecond()
        {
            return WarriorChangePerSecond;
        }

        private void PeasantOnClick()
        {
            _peasantHuntingProcess = true;
            _peasantHuntingDeltaTime = PeasantHuntingTime;
            headerResources.ChangeMoonshine(-PeasantPrice);
        }

        private void WarriorOnClick()
        {
            _warriorHuntingProcess = true;
            _warriorHuntingDeltaTime = WarriorHuntingTime;
            headerResources.ChangeMoonshine(-WarriorPrice);
        }
    }
}