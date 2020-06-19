﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    public ParticleSystem explosion;

    private bool destroed;
    private void OnCollisionEnter(Collision other)
    {
        Messenger.Broadcast(GameEvent.EnemyCollision);
        StartCoroutine(DestroyEnemy());
    }

    private IEnumerator DestroyEnemy()
    {
        if (!destroed)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            destroed = true;
            explosion.Play();
        
            yield return  new WaitForSeconds(1);
        
            Destroy(gameObject);
        }
        
    }
}