using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider musicSlider;

    public Slider soundsSlider;

    public SwitchManager musicToggle;

    public SwitchManager soundsToggle;

    private AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<AudioSource>();
        SetAudioUI();
        musicSlider.onValueChanged.AddListener(delegate { ChangeMusicVolume(musicSlider.value); });
        soundsSlider.onValueChanged.AddListener(delegate { ChangeSoundsVolume(soundsSlider.value); });
    }

    public void TurnMusic(bool turn)
    {
        if (turn)
        {
            click.Play();
            mixer.SetFloat("MusicVolume", 0);
            Managers.Settings.settings.musicVolume = 0;
        }
        else
        {
            click.Play();
            mixer.SetFloat("MusicVolume", -80);
            Managers.Settings.settings.musicVolume = -80f;
        }
    }

    public void TurnSounds(bool turn)
    {
        if (turn)
        {
            click.Play();
            mixer.SetFloat("SoundsVolume", 0);
            Managers.Settings.settings.soundVolume = 0;
        }
        else
        {
            click.Play();
            mixer.SetFloat("SoundsVolume", -80);
            Managers.Settings.settings.soundVolume = -80f;
        }
    }

    private void ChangeMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
        Managers.Settings.settings.musicVolume = volume;
    }

    private void ChangeSoundsVolume(float volume)
    {
        if(!click.isPlaying) click.Play();
        mixer.SetFloat("SoundsVolume", volume);
        Managers.Settings.settings.soundVolume = volume;
    }

    private void SetAudioUI()
    {
        musicSlider.value = Managers.Settings.settings.musicVolume;
        soundsSlider.value = Managers.Settings.settings.soundVolume;
        if (Managers.Settings.settings.musicVolume == -80f)
        {
            musicToggle.isOn = false;
        }
        else
        {
            musicToggle.isOn = true;
        }
        if (Managers.Settings.settings.soundVolume == -80f)
        {
            soundsToggle.isOn = false;
        }
        else
        {
            soundsToggle.isOn = true;
        }
    }
}
