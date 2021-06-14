using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Sprite muteImage;
    [SerializeField] private Sprite unMuteImage;
    [SerializeField] private SoundManager soundManager;

    private Button _button;
    private bool _mute;

    // Start is called before the first frame update
    void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _mute = !_mute;
        soundManager.Mute(_mute);
        if (_mute)
        {
            _button.image.sprite = muteImage;
        }
        else
        {
            _button.image.sprite = unMuteImage;
        }
    }
}