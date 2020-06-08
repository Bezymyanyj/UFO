using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}

    public Dictionary<string, KeyCode> KeyCodes = new Dictionary<string, KeyCode>()
    {
        {"PushUp", KeyCode.W},
        {"PushDown", KeyCode.S},
        {"PushLeft", KeyCode.A},
        {"PushRight", KeyCode.D}
    };

    public void Startup(){
        Debug.Log("Player manager starting...");
        
        

        status = ManagerStatus.Started;

        
    }
    
}
