using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider musicSlider;

    public Slider soundsSlider;
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.onValueChanged.AddListener(delegate { ChangeMusicVolume(musicSlider.value); });
        soundsSlider.onValueChanged.AddListener(delegate { ChangeSoundsVolume(soundsSlider.value); });
    }

    public void TurnMusic(bool turn)
    {
        if (turn)
            mixer.SetFloat("MusicVolume", 0);
        else
            mixer.SetFloat("MusicVolume", -80);
    }

    public void TurnSounds(bool turn)
    {
        if (turn)
            mixer.SetFloat("SoundsVolume", 0);
        else
            mixer.SetFloat("SoundsVolume", -80);
    }

    private void ChangeMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
    }

    private void ChangeSoundsVolume(float volume)
    {
        mixer.SetFloat("SoundsVolume", volume);
    }
}
