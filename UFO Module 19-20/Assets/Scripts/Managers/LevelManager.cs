using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}

    public int CurrentLevel{get; private set;}
    
    public void Startup(){
        Debug.Log("Player manager starting...");

        CurrentLevel = SceneManager.GetActiveScene().buildIndex;

        status = ManagerStatus.Started;
    }


    public void Restart(){
        SceneManager.LoadScene(CurrentLevel);
    }

    public void LoadNextLevel(){
        SceneManager.LoadScene(++CurrentLevel);
    }
}
