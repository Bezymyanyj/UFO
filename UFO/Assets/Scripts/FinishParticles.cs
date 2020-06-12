using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishParticles : MonoBehaviour
{
    public ParticleSystem[] fireWorks;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.Level_Complete, StartParticles);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.Level_Complete, StartParticles);
    }

    private void StartParticles()
    {
        for (int i = 0; i < fireWorks.Length; i++)
        {
            fireWorks[i].Play();
        }
    }
}
