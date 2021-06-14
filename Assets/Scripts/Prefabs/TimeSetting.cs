using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class TimeSetting : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    public int defaultValue;

    private void Start()
    {
        inputField.text = defaultValue.ToString();
    }

    public int GetValue()
    {
        int.TryParse(inputField.text, out var value);
        return value;
    }
}