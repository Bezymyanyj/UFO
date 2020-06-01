using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject mainMenuWindow;
    public GameObject optionsWindow;
    public GameObject audioWindow;
    public GameObject videoWindow;
    public GameObject keyWindow;

    public Dictionary<string, GameObject> Windows= new Dictionary<string, GameObject>();

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Windows.Add("audio", audioWindow);
        Windows.Add("video", videoWindow);
        Windows.Add("key", keyWindow);
    }
    public void StartGame(){
        Messenger.Broadcast("Next_Level");
    }
    public void ExitApplication(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenOptions(){
        mainMenuWindow.SetActive(false);
        optionsWindow.SetActive(true);
    }

    public void OpenMainMenu(){
        mainMenuWindow.SetActive(true);
        optionsWindow.SetActive(false);
    }

    public void ChangeOptionWindow(string key){
        Windows[key].SetActive(true);
        foreach(KeyValuePair<string, GameObject> window in Windows){
            if(window.Key != key)
                window.Value.SetActive(false);
        }
    }
}
