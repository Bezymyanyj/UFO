using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status {get; private set;}

    public int Score {get; private set;}
    private int Health{get; set;}
    private int MaxHealth{get; set;}
    
    private int value = -25; //Величина урона

    private void Awake()
    {
        Messenger.AddListener(GameEvent.EnemyCollision, ChangeHealth);
        Messenger.AddListener(GameEvent.LevelFailed, SetHealth);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.EnemyCollision, ChangeHealth);
        Messenger.RemoveListener(GameEvent.LevelFailed, SetHealth);
    }


    public void Startup(){
        Debug.Log("Player manager starting...");

        Health = 100;
        MaxHealth = 100;

        Status = ManagerStatus.Started;
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
            Messenger.Broadcast(GameEvent.LevelFailed);

        // Debug.Log($"Health: {Health} / {MaxHealth}");
    }

    /// <summary>
    /// Востанавливаем здоровье на рестарте
    /// </summary>
    private void SetHealth() => Health = 100;
}
