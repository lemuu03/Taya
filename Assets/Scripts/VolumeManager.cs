  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] float musicValue;
    [SerializeField] Slider musicSlider;
    [SerializeField] float sfxValue;
    [SerializeField] Slider sfxSlider;
    
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music");
        sfxSlider.value = PlayerPrefs.GetFloat("sfx");
    }

    void Update()
    {
        myMixer.SetFloat("music", Mathf.Log10(musicValue) * 20f);
        PlayerPrefs.SetFloat("music", musicValue);

        myMixer.SetFloat("sfx", Mathf.Log10(sfxValue) * 20f);
        PlayerPrefs.SetFloat("sfx", sfxValue);
    }
    public void SetMusicVolume(float level)
    {
        musicValue = level;
        // myMixer.SetFloat("music", Mathf.Log10(level) * 20f);
    }

    public void SetSoundFXVolume(float level)
    {
        sfxValue = level;
        // myMixer.SetFloat("sfx", Mathf.Log10(level) * 20f);
    }

    // private void Start()
    // {
    //     if(PlayerPrefs.HasKey("music"))
    //     { 
    //         LoadVolume();
    //     }
    //     else
    //     {
    //         SetVolume();
    //         SetSoundFX();
    //     }

    // }
    // public void SetVolume()
    // {
    //     float volume = musicSlider.value;
    //     myMixer.SetFloat("music", volume);
    //     PlayerPrefs.SetFloat("music", Mathf.Log10(level) * 20f);
    // }

    // public void SetSoundFX()
    // {
    //     // myMixer.SetFloat("sfx", level);
    //     float volume = musicSlider.value;
    //     myMixer.SetFloat("sfx", volume);
    //     PlayerPrefs.SetFloat("sfx", Mathf.Log10(level) * 20f);
    // }
    // private void LoadVolume()
    // {
    //     musicSlider.value = PlayerPrefs.GetFloat("music");
    //     musicSlider.value = PlayerPrefs.GetFloat("sfx");

    //     SetVolume();
    // }

    // public void On()
    // {
    //     AudioListener.volume = 0;
    //     ON.SetActive(false);
    //     OFF.SetActive(true);
    // }

    // public void Off()
    // {
    //     AudioListener.volume = 1;
    //     ON.SetActive(true);
    //     OFF.SetActive(false);
    // }
}
