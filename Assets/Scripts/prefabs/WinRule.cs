using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinRule : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Text[] texts;
    public int defaultValue;

    private static readonly Color EnableTextColor = new Color(0.196f, 0.196f, 0.196f);

    private static readonly Color DisableTextColor = new Color(0.40f, 0.34f, 0.28f);

//"645443"
    private void Start()
    {
        toggle.onValueChanged.AddListener(HandleCheckbox);
        inputField.text = defaultValue.ToString();
    }

    public void HandleCheckbox(bool value)
    {
        toggle.isOn = value;
        inputField.interactable = value;

        foreach (Text text in texts)
        {
            if (value)
            {
                text.color = EnableTextColor;
            }
            else
            {
                text.color = DisableTextColor;
            }
        }
    }

    public int GetValue()
    {
        if (toggle.isOn)
        {
            int.TryParse(inputField.text, out var value);
            return value;
        }
        else
        {
            return 0;
        }
    }
}