using System;
using UnityEngine;
using UnityEngine.UI;

namespace footer
{
    public class SpeedGame : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button normalSpeedButton;
        [SerializeField] private Button doubleSpeedButton;
        private static readonly Color ActiveColor = new Color(0.25f, 0.47f, 0.28f);
        private bool _paused;

        private int _timeScale = 1;

        private void Start()
        {
            pauseButton.onClick.AddListener(PauseGame);
            normalSpeedButton.onClick.AddListener(NormalSpeedGame);
            doubleSpeedButton.onClick.AddListener(DoubleSpeedGame);
            Reset();
        }

        public void Reset()
        {
            NormalSpeedGame();
        }

        private void PauseGame()
        {
            ChangeSpeed(0);
        }

        private void NormalSpeedGame()
        {
            ChangeSpeed(1);
        }

        private void DoubleSpeedGame()
        {
            ChangeSpeed(2);
        }

        private void ChangeSpeed(int newSpeed)
        {
            if (newSpeed != 0)
            {
                _timeScale = newSpeed;
                _paused = false;
            }
            else
            {
                if (_paused)
                {
                    newSpeed = _timeScale;
                }

                _paused = !_paused;
            }

            Time.timeScale = newSpeed;

            switch (newSpeed)
            {
                case 0:
                    SetActiveColors(pauseButton);
                    ResetColor(normalSpeedButton);
                    ResetColor(doubleSpeedButton);
                    break;
                case 1:
                    ResetColor(pauseButton);
                    SetActiveColors(normalSpeedButton);
                    ResetColor(doubleSpeedButton);
                    break;
                default:
                    ResetColor(pauseButton);
                    ResetColor(normalSpeedButton);
                    SetActiveColors(doubleSpeedButton);
                    break;
            }
        }

        private static void SetActiveColors(Button button)
        {
            var buttonColors = button.colors;
            buttonColors.normalColor = ActiveColor;
            buttonColors.selectedColor = ActiveColor;
            button.colors = buttonColors;
        }

        private static void ResetColor(Button button)
        {
            var buttonColors = button.colors;
            buttonColors.normalColor = Color.white;
            buttonColors.selectedColor = Color.white;
            button.colors = buttonColors;
        }
    }
}