﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Tutorial : MonoBehaviour
{
    public GameObject tutorialWindow;
    // Start is called before the first frame update
    void Start()
    {
        if(!Managers.Level.IsTutorialComplete){
            Time.timeScale = 0;
            Messenger.Broadcast(GameEvent.Game_Paused);
        }
        else{
            tutorialWindow.SetActive(false);
            
        }

    }

    public void StartGame(){
        tutorialWindow.SetActive(false);
        Managers.Level.IsTutorialComplete = true;
        Time.timeScale = 1;
        Messenger.Broadcast(GameEvent.Game_UnPaused);
    }
}