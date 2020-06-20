using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Explossion : MonoBehaviour
{
    private bool isFailed;
    public ParticleSystem explosion;
    public GameObject deathBody;
    public GameObject body;

    private AudioSource explosionAudio;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        explosionAudio = GetComponent<AudioSource>();
        Messenger.AddListener(GameEvent.LevelFailed, OnFailed);
    }


    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy() => Messenger.RemoveListener(GameEvent.LevelFailed, OnFailed);
    
    private void OnFailed()
    {
        if (isFailed) return;
        isFailed = true;
        explosion.Play();
        explosionAudio.Play();
        deathBody.SetActive(true);
        body.SetActive(false);
    }
}
