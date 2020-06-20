using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    private string[] windowsName;
    public GameObject[] optionWindows;
    public GameObject mainMenuWindow;
    public GameObject optionsWindow;

    private AudioSource click;

    public Dictionary<string, GameObject> Windows = new Dictionary<string, GameObject>();
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        click = GetComponent<AudioSource>();
        
        for(int i = 0; i < optionWindows.Length; i++){
            Windows.Add(optionWindows[i].name, optionWindows[i]);
        }
    }
    public void StartGame(){
        click.Play();
        Messenger.Broadcast(GameEvent.NextLevel);
    }
    public void ExitApplication(){
        click.Play();
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenMainMenu(){
        click.Play();
        mainMenuWindow.SetActive(true);
        Managers.Settings.WriteSettings();
        optionsWindow.SetActive(false);
    }

    public void OpenOptions(){
        click.Play();
        optionsWindow.SetActive(true);
        mainMenuWindow.SetActive(false);
    }
    /// <summary>
    /// Открывает вкладки настроек
    /// </summary>
    /// <param name="key">Имя меню</param>
    public void OpenWindow(string key)
    {
        Windows[key].SetActive(true);
        foreach (var window in Windows.Where(window => window.Key != key))
        {
            window.Value.SetActive(false);
            click.Play();
        }
    }
}
