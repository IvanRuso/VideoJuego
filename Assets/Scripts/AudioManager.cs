using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] music;
    public AudioSource[] sfx;
    public int bgmMusic;
    public AudioMixerGroup masterMixer,musicMixer, sfxMixer;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {

        //PlayMusic(bgmMusic);
        SetMasterLevel();
        SetMusicLevel();
        SetSFXLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(int musicToPlay)
    {
        music[musicToPlay].Play();
    }
    public void StopMusic(int musicToPlay)
    {
        music[musicToPlay].Stop();
    }

    public void SoundEffects(int effectToPlay)
    {
        sfx[effectToPlay].Play();
    }

    public void SetMusicLevel()
    {
        musicMixer.audioMixer.SetFloat("MusicVol", Mathf.Log10(UIManager.instance.musicVolumeSlider.value)*20);
    }

    public void SetSFXLevel()
    {
        sfxMixer.audioMixer.SetFloat("SFXVol", Mathf.Log10(UIManager.instance.sfxVolumeSlider.value)*20);
    }
    public void SetMasterLevel()
    {
        masterMixer.audioMixer.SetFloat("MasterVol", Mathf.Log10(UIManager.instance.masterVolumeSlider.value)*20);
    }
}
