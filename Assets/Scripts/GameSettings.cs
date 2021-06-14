using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private TimeSetting firstAttack;
    [SerializeField] private TimeSetting periodAttack;

    [SerializeField] private WinRule moonshine;
    [SerializeField] private WinRule warrior;
    [SerializeField] private WinRule attack;


    private void Start()
    {
        moonshine.HandleCheckbox(true);
        warrior.HandleCheckbox(false);
        attack.HandleCheckbox(false);
    }

    public int GetFirstAttack()
    {
        return firstAttack.GetValue();
    }

    public int GetPeriodAttack()
    {
        return periodAttack.GetValue();
    }

    public int GetMoonshineWin()
    {
        return moonshine.GetValue();
    }

    public int GetWarriorWin()
    {
        return warrior.GetValue();
    }

    public int GetAttackWin()
    {
        return attack.GetValue();
    }
}