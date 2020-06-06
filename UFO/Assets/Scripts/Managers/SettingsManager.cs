using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}
    
    public void Startup(){
        Debug.Log("Player manager starting...");


        status = ManagerStatus.Started;
    }
}
