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
        SetVolume();
        musicSlider.onValueChanged.AddListener(delegate { ChangeMusicVolume(musicSlider.value); });
        soundsSlider.onValueChanged.AddListener(delegate { ChangeSoundsVolume(soundsSlider.value); });
    }

    /// <summary>
    /// Выключаем включаем музыку
    /// </summary>
    /// <param name="turn"></param>
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

    /// <summary>
    /// Выключаем включаем звуки
    /// </summary>
    /// <param name="turn"></param>
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

    /// <summary>
    /// Изменяем громкость музыки слайдером
    /// </summary>
    /// <param name="volume"></param>
    private void ChangeMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
        Managers.Settings.settings.musicVolume = volume;
    }

    /// <summary>
    /// Изменяем громкость звуков слайдером
    /// </summary>
    /// <param name="volume"></param>
    private void ChangeSoundsVolume(float volume)
    {
        if(!click.isPlaying) click.Play();
        mixer.SetFloat("SoundsVolume", volume);
        Managers.Settings.settings.soundVolume = volume;
    }

    /// <summary>
    /// Устанавливаем элементы интерфейса в правильное положение на старте,согласно настройкам пользователя
    /// </summary>
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

    private void SetVolume()
    {
        mixer.SetFloat("MusicVolume",  Managers.Settings.settings.musicVolume);
        mixer.SetFloat("SoundsVolume", Managers.Settings.settings.soundVolume);
    }
}
