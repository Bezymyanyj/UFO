using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishParticles : MonoBehaviour
{
    public ParticleSystem[] fireWorks;

    private void Awake() => Messenger.AddListener(GameEvent.LevelComplete, StartParticles);

    private void OnDestroy() => Messenger.RemoveListener(GameEvent.LevelComplete, StartParticles);

    private void StartParticles()
    {
        foreach (var particle in fireWorks)
        {
            particle.Play();
        }
    }
}
