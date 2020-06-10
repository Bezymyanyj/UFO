using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Level : MonoBehaviour
{
    
    private string[] windowsName;
    public GameObject[] optionWindows;
    public GameObject pauseWindow;
    public GameObject finishWindow;
    public GameObject optionsWindow;
    public Dictionary<string, GameObject> Windows = new Dictionary<string, GameObject>();
    private bool isPause;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Messenger.AddListener("Level_Complete", LevelComplete);
    }
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        Messenger.RemoveListener("Level_Complete", LevelComplete);
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        for(int i = 0; i < optionWindows.Length; i++){
            Windows.Add(optionWindows[i].name, optionWindows[i]);
        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!isPause){
                Pause();
            }
            else{
                UnPause();
            }
        }
    }
    
    private void Pause(){
        isPause = true;
        Messenger.Broadcast(GameEvent.Game_Paused);
        Time.timeScale = 0;
        pauseWindow.SetActive(true);
    }
    public void UnPause(){
        isPause = false;
        Messenger.Broadcast(GameEvent.Game_UnPaused);
        Time.timeScale = 1;
        pauseWindow.SetActive(false);
    }

    public void ExitApplication(){
        Debug.Log("Quit");
        Application.Quit();
    }
    public void OpenMainMenu(){
        pauseWindow.SetActive(true);
        Managers.Settings.WriteSettings();
        optionsWindow.SetActive(false);
    }

    public void OpenOptions(){
        optionsWindow.SetActive(true);
        pauseWindow.SetActive(false);
    }

    public void OpenWindow(string key){
        Windows[key].SetActive(true);
        foreach(KeyValuePair<string, GameObject> window in Windows){
            if(window.Key != key)
                window.Value.SetActive(false);
        }
    }

    public void LoadNextLevel(){
        Messenger.Broadcast(GameEvent.Next_Level);
    }

    private void LevelComplete(){
        finishWindow.SetActive(true);
    }
}
