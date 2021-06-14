using Prefabs;
using UnityEngine;

namespace body
{
    public class WinRulePanel : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private HeaderResource wave;
        [SerializeField] private HeaderResource warrior;
        [SerializeField] private HeaderResource moonshine;


        public void Reset()
        {
            wave.gameObject.SetActive(false);
            warrior.gameObject.SetActive(false);
            moonshine.gameObject.SetActive(false);

            if (gameSettings.GetAttackWin() != 0)
            {
                wave.gameObject.SetActive(true);
                wave.SetCount(gameSettings.GetAttackWin());
            }

            if (gameSettings.GetWarriorWin() != 0)
            {
                warrior.gameObject.SetActive(true);
                warrior.SetCount(gameSettings.GetWarriorWin());
            }

            if (gameSettings.GetMoonshineWin() != 0)
            {
                moonshine.gameObject.SetActive(true);
                moonshine.SetCount(gameSettings.GetMoonshineWin());
            }
        }

        void Start()
        {
            Reset();
        }
    }
}