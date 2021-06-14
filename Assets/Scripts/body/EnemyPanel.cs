using System;
using header;
using UnityEngine;
using UnityEngine.UI;

namespace body
{
    public class EnemyPanel : MonoBehaviour
    {
        [SerializeField] private Image enemy;
        [SerializeField] private HeaderResources headerResources;
        [SerializeField] private HeaderEnemies headerEnemies;
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private SoundManager soundManager;

        private const float WaveTime = 10f;
        private const float AttackTime = 2f;
        private float _deltaWaveTime = WaveTime;
        private float _attackTime = AttackTime;
        private bool _isAttack;
        private int _countEnemies = 1;

        private float _waveTime = 0;


        public void Reset()
        {
            SetFirstAttack();
            _countEnemies = 1;
            headerEnemies.Reset();
            gameObject.GetComponent<Image>().enabled = false;
        }

        private void Start()
        {
            Reset();
        }


        private void Update()
        {
            if (!_isAttack)
            {
                _deltaWaveTime -= Time.deltaTime;

                headerEnemies.ActivateBarPoints(Mathf.FloorToInt(10 - (_deltaWaveTime * 100 / _waveTime / 10)));
            }

            if (_isAttack || _deltaWaveTime <= 0)
            {
                SetNextWaveTime();
                Attack();
            }
        }

        private void Attack()
        {
            var enemyTransform = enemy.transform;
            _attackTime -= Time.deltaTime;
            if (_attackTime <= 0)
            {
                _isAttack = false;
                enemyTransform.position = new Vector2(0, enemyTransform.position.y);
                headerResources.ChangeWarrior(-_countEnemies);
                headerEnemies.SetEnemy(_countEnemies);
                headerEnemies.ClearBar();
                _countEnemies++;
                _attackTime = AttackTime;
                gameObject.GetComponent<Image>().enabled = false;
                soundManager.StopAttack();
            }
            else
            {
                if (!_isAttack)
                {
                    soundManager.PlayAttack(AttackTime);
                }

                _isAttack = true;
                float areaWidth = gameObject.GetComponent<RectTransform>().rect.width;
                float imageWidth = enemy.rectTransform.rect.width;
                float changeEnemyPosition = (imageWidth + areaWidth) * (1 - (_attackTime / AttackTime));

                enemyTransform.position = new Vector2(changeEnemyPosition, enemyTransform.position.y);
                gameObject.GetComponent<Image>().enabled = true;
            }
        }

        public int GetCountEnemies()
        {
            return _countEnemies;
        }

        private void SetFirstAttack()
        {
            if (gameSettings.GetFirstAttack() == 0)
            {
                _waveTime = WaveTime;
            }
            else
            {
                _waveTime = gameSettings.GetFirstAttack();
            }

            _deltaWaveTime = _waveTime;
        }

        private void SetNextWaveTime()
        {
            if (gameSettings.GetPeriodAttack() == 0)
            {
                _waveTime = WaveTime;
            }
            else
            {
                _waveTime = gameSettings.GetPeriodAttack();
            }

            _deltaWaveTime = _waveTime;
        }
    }
}