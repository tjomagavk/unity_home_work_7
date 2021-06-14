using System;
using System.Collections;
using System.Collections.Generic;
using body;
using footer;
using header;
using prefabs;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] private Body body;
    [SerializeField] private HeaderResources headerResources;
    [SerializeField] private EnemyPanel enemyPanel;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private SpeedGame speedGame;
    [SerializeField] private Finish finish;

    public void Reset()
    {
        body.Reset();
        headerResources.Reset();
        enemyPanel.Reset();
        speedGame.Reset();
    }

    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (headerResources.GetWarriorCount() < 0)
        {
            Fail();
        }

        bool winRule = true;
        if (gameSettings.GetAttackWin() == 0
            && gameSettings.GetWarriorWin() == 0
            && gameSettings.GetMoonshineWin() == 0)
        {
        }
        else
        {
            if (gameSettings.GetAttackWin() != 0 && enemyPanel.GetCountEnemies() <= gameSettings.GetAttackWin())
            {
                winRule = false;
            }

            if (gameSettings.GetWarriorWin() != 0 && headerResources.GetWarriorCount() < gameSettings.GetWarriorWin())
            {
                winRule = false;
            }

            if (gameSettings.GetMoonshineWin() != 0 &&
                headerResources.GetMoonshineCount() < gameSettings.GetMoonshineWin())
            {
                winRule = false;
            }
        }

        if (winRule)
        {
            Win();
        }
    }

    private void Win()
    {
        finish.Render(true);
        gameObject.SetActive(false);
    }

    private void Fail()
    {
        finish.Render(false);
        gameObject.SetActive(false);
    }
}