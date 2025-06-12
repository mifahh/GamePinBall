using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private enum SFXName
    { 
        BumperSFX = 0,
        SwitchSFX = 1,
        PaddleSFX = 2
    }

    public AudioSource bgmAudioSource;
    public GameObject[] SFXAudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        //Play BGM saat game dimulai
        PlayBGM();
    }

    //fungsi menjalankan BGM dari script lain
    public void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    //fungsi menjalankan SFX dari script lain
    public void PlaySFX(Vector3 spawnPosition, string name)
    {
        Enum.TryParse<SFXName>(name, out SFXName sfxName);
        int sfxIndex = (int)sfxName;

        Instantiate(SFXAudioSource[sfxIndex], spawnPosition, Quaternion.identity);
    }
}
