using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}

    public int Score {get; private set;}
    private int Health{get; set;}
    private int MaxHealth{get; set;}

    public int value = -25;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.EnemyCollision, ChangeHealth);
        Messenger.AddListener(GameEvent.Level_Failed, SetHealth);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.EnemyCollision, ChangeHealth);
        Messenger.RemoveListener(GameEvent.Level_Failed, SetHealth);
    }


    public void Startup(){
        Debug.Log("Player manager starting...");

        Health = 100;
        MaxHealth = 100;

        status = ManagerStatus.Started;
    }

    private void ChangeHealth(){
        Health += value;
        if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        else if (Health < 0){
            Health = 0;
        }
        
        if(Health == 0)
            Messenger.Broadcast(GameEvent.Level_Failed);

        Debug.Log($"Health: {Health} / {MaxHealth}");
    }
    
    public void SetHealth()
    {
        Health = 100;
        Debug.Log($"Health: {Health} / {MaxHealth}");
    }
    
}
