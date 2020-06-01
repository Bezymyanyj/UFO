using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject mainMenuWindow;
    public GameObject optionsWindow;

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
}
