using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance;

    [SerializeField]
    private AudioSource _audioSourceSFX;
    [SerializeField]
    private AudioClip 
        _sfxLoss,
        _sfxSelect,
        _sfxPoint,
        _sfxPowerUp,
        _sfxShot,
        _sfxDash,
        _sfxExplosion,
        _sfxWin;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySfxLoss()
    {
        _audioSourceSFX.PlayOneShot(_sfxLoss);
    }

    public void PlaySfxSelect()
    {
        _audioSourceSFX.PlayOneShot(_sfxSelect);
    }

    public void PlaySfxPoint()
    {
        _audioSourceSFX.PlayOneShot(_sfxPoint);
    }

    public void PlaySfxPowerUp()
    {
        _audioSourceSFX.PlayOneShot(_sfxPowerUp);
    }

    public void PlaySfxShot()
    {
        _audioSourceSFX.PlayOneShot(_sfxShot);
    }

    public void PlaySfxDash()
    {
        _audioSourceSFX.PlayOneShot(_sfxDash);
    }

    public void PlaySfxExplosion()
    {
        _audioSourceSFX.PlayOneShot(_sfxExplosion);
    }

    public void PlaySfxWin()
    {
        _audioSourceSFX.PlayOneShot(_sfxWin);
    }
}
