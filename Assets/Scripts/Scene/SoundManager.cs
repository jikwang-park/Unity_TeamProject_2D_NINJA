using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audioMixer;

   


    private void Start()
    {
        SoundOptionSet();
    }

    public void SFXVolumSet(float vol)
    {

        audioMixer.SetFloat("Sfx", Mathf.Log10(vol)*20);
    }
    public void BGMVolumSet(float vol)
    {

        audioMixer.SetFloat("Bgm", Mathf.Log10(vol)*20);
    }
    public void SoundOptionSet()
    {
        
    }
}
