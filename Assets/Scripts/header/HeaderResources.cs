using System;
using prefabs;
using UnityEngine;

namespace header
{
    public class HeaderResources : MonoBehaviour
    {
        [SerializeField] private HeaderResource peasant;
        [SerializeField] private HeaderResource warrior;
        [SerializeField] private HeaderResource moonshine;

        public void Reset()
        {
            peasant.SetCount(1);
            warrior.SetCount(0);
            moonshine.SetCount(0);
        }

        private void Start()
        {
            Reset();
        }

        public int GetPeasantCount()
        {
            return peasant.GetCount();
        }

        public void SetPeasant(int value)
        {
            peasant.SetCount(value);
        }

        public void ChangePeasant(int value)
        {
            peasant.SetCount(peasant.GetCount() + value);
        }

        public int GetWarriorCount()
        {
            return warrior.GetCount();
        }

        public void SetWarrior(int value)
        {
            warrior.SetCount(value);
        }

        public void ChangeWarrior(int value)
        {
            warrior.SetCount(warrior.GetCount() + value);
        }

        public int GetMoonshineCount()
        {
            return moonshine.GetCount();
        }

        public void SetMoonshine(int value)
        {
            moonshine.SetCount(value);
        }


        public void ChangeMoonshine(int value)
        {
            int newValue = moonshine.GetCount() + value;
            if (newValue < 0)
            {
                newValue = 0;
                ChangeWarrior(-1);
            }

            moonshine.SetCount(newValue);
        }
    }
}