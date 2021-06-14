using System;
using System.Collections;
using System.Collections.Generic;
using body;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource attackMusic;
    private bool _isAttack;
    private bool _isMute;
    private const float FadeTime = 1.3f;
    private float _attackTime;

    private void Start()
    {
        PlayBackground();
    }

    private void Update()
    {
        if (attackMusic.volume > 0 && _attackTime <= .5f)
        {
            attackMusic.volume = attackMusic.volume - (Time.deltaTime / FadeTime);
        }
        else if (_isAttack)
        {
            _attackTime -= Time.deltaTime;
            attackMusic.volume = attackMusic.volume + (Time.deltaTime / FadeTime);
            if (!attackMusic.isPlaying)
            {
                attackMusic.Play();
            }
        }
    }

    public void Mute(bool mute)
    {
        attackMusic.mute = mute;
        backgroundMusic.mute = mute;
    }

    public void PlayAttack(float time)
    {
        _attackTime = time;
        _isAttack = true;
    }

    public void StopAttack()
    {
        _isAttack = false;
    }

    private void PlayBackground()
    {
        backgroundMusic.loop = true;
        backgroundMusic.Play();
    }
}