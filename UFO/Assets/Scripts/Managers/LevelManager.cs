using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}

    public int CurrentLevel{get; private set;}
    public bool IsTutorialComplete{get; set;}

    private bool isRestart;
    
    public void Startup(){
        Debug.Log("Player manager starting...");

        CurrentLevel = SceneManager.GetActiveScene().buildIndex;

        isRestart = false;

        status = ManagerStatus.Started;
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Messenger.AddListener("Level_Failed", OnFailed);
        Messenger.AddListener("Next_Level", LoadNextLevel);
    }
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        Messenger.RemoveListener("Level_Failed", OnFailed);
        Messenger.RemoveListener("Next_Level", LoadNextLevel);
    }

    private void OnFailed(){
        if(!isRestart){
            StartCoroutine(Restart());
        }
    }

    private IEnumerator Restart(){
        isRestart = true;

        yield return new WaitForSeconds(1);
        isRestart = false;
        SceneManager.LoadScene(CurrentLevel);
    }

    private void LoadNextLevel(){
        SceneManager.LoadScene(++CurrentLevel);
    }
}
