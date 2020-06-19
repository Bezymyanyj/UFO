using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollider : MonoBehaviour
{

    private AudioSource finishAudio;


    private void Start()
    {
        finishAudio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            finishAudio.Play();
            Messenger.Broadcast(GameEvent.Level_Complete);
            Messenger.Broadcast(GameEvent.Game_Paused);
        }
    }
}
