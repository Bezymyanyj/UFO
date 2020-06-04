using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    private string[] windowsName;
    public GameObject[] optionWindows;
    public GameObject mainMenuWindow;
    public GameObject optionsWindow;

    public Dictionary<string, GameObject> Windows = new Dictionary<string, GameObject>();
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
    public void StartGame(){
        Messenger.Broadcast(GameEvent.Next_Level);
    }
    public void ExitApplication(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenMainMenu(){
        mainMenuWindow.SetActive(true);
        optionsWindow.SetActive(false);
    }

    public void OpenOptions(){
        optionsWindow.SetActive(true);
        mainMenuWindow.SetActive(false);
    }

    public void OpenWindow(string key){
        Windows[key].SetActive(true);
        foreach(KeyValuePair<string, GameObject> window in Windows){
            if(window.Key != key)
                window.Value.SetActive(false);
        }
    }
}
