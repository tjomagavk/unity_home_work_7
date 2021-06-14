using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private Text finishText;

    private const string WinText = "Победа!";
    private const string FailText = "Поражение...";

    public void Render(bool win)
    {
        gameObject.SetActive(true);
        finishText.text = win ? WinText : FailText;
    }
}