using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(LevelManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player{get; private set;}
    public static LevelManager Level{get; private set;}
    public static ControlsManager Control { get; private set; }
    public static SettingsManager Settings { get; private set; }

    private List<IGameManager> startSequence;

    private void Awake() {
        Player = GetComponent<PlayerManager>();
        Level = GetComponent<LevelManager>();
        Control = GetComponent<ControlsManager>();
        Settings = GetComponent<SettingsManager>();
        
        startSequence = new List<IGameManager>();
        startSequence.Add(Player);
        startSequence.Add(Level);
        startSequence.Add(Control);
        startSequence.Add(Settings);

        StartCoroutine(StartupManagers());

        DontDestroyOnLoad(this.gameObject);
    }

    private IEnumerator StartupManagers(){
        foreach(IGameManager manager in startSequence){
            manager.Startup();
        }

        yield return null;

        int numModules = startSequence.Count;
        int numReady = 0;

        while(numReady < numModules){
            int lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in startSequence){
                if(manager.status == ManagerStatus.Started){
                    numReady++;
                }
            }

            if (numReady > lastReady){
                Debug.Log($"Progress: {numReady} / {numModules}");
            }
            yield return null;
        }
        Debug.Log("All managers stated up");
    }
    
}
