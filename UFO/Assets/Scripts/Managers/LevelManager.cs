using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status {get; private set;}

    public bool IsTutorialComplete{get; set;}
    public float CurrentRecord { get; set; }
    
    public Dictionary<string, float> timeLevel = new Dictionary<string, float>();
    
    private int сurrentLevel;
    private bool isRestart;
    
    public void Startup(){
        Debug.Log("Player manager starting...");

        сurrentLevel = SceneManager.GetActiveScene().buildIndex;

        isRestart = false;
        
        StartCoroutine(AddSceneRecords());

        Status = ManagerStatus.Started;
    }
    void Awake()
    {
        Messenger.AddListener(GameEvent.LevelFailed, OnFailed);
        Messenger.AddListener(GameEvent.NextLevel, LoadNextLevel);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.LevelFailed, OnFailed);
        Messenger.RemoveListener(GameEvent.NextLevel, LoadNextLevel);
    }

    #region Restart
    
    private void OnFailed(){
        if(!isRestart){
            StartCoroutine(Restart());
        }
    }

    private IEnumerator Restart(){
        isRestart = true;

        yield return new WaitForSeconds(1);
        isRestart = false;
        SceneManager.LoadScene(сurrentLevel);
    }
    #endregion

    private void LoadNextLevel() => SceneManager.LoadScene(++сurrentLevel);

    /// <summary>
    /// Загруаем текущие рекорды уровней на старте игры
    /// </summary>
    /// <returns></returns>
    private IEnumerator AddSceneRecords()
    {
        yield return new WaitForSeconds(0.1f);
        timeLevel.Add(Managers.Settings.records.levelRecords[0].levelName, Managers.Settings.records.levelRecords[0].recordTime);
        timeLevel.Add(Managers.Settings.records.levelRecords[1].levelName, Managers.Settings.records.levelRecords[1].recordTime);
    }
}
