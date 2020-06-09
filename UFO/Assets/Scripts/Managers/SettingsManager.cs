using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SettingsManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}
    
    [HideInInspector]
    public Settings settings = new Settings();
    
    
    private string jsonPath = "/settings.json";
    
    public void Startup(){
        Debug.Log("Player manager starting...");

        if (File.Exists(Application.dataPath + jsonPath))
        {
            LoadSettings();
        }
        else
        {
            CreateSettings();
        }

        //DebugSettings();
        status = ManagerStatus.Started;
    }

    private void LoadSettings()
    {
        using (StreamReader stream = new StreamReader(Application.dataPath + jsonPath))
        {
            string json = stream.ReadToEnd();
            settings = JsonUtility.FromJson<Settings>(json);
        }
    }

    public void WriteSettings()
    {
        Managers.Control.WriteKeyCodes();
        
        using (StreamWriter stream = new StreamWriter(Application.dataPath + jsonPath))
        {
            string json = JsonUtility.ToJson(settings);
            stream.Write(json);
        }
    }

    private void CreateSettings()
    {
        settings.musicVolume = 0;
        settings.soundVolume = 0;
        settings.fullScreen = true;
        settings.screenSize = "1920x1080";
        settings.resolutionIndex = 4;
        settings.pushUp = "W";
        settings.pushDown = "S";
        settings.pushLeft = "A";
        settings.pushRight = "D";
        
        using (StreamWriter stream = new StreamWriter(Application.dataPath + jsonPath))
        {
            string json = JsonUtility.ToJson(settings);
            stream.Write(json);
        }
    }

    public Settings GetSettings()
    {
        return settings;
    }

    public void DebugSettings()
    {
        Debug.Log(settings.pushUp);
        Debug.Log(settings.pushDown);
        Debug.Log(settings.pushLeft);
        Debug.Log(settings.pushRight);
        Debug.Log(settings.fullScreen.ToString());
        Debug.Log(settings.screenSize);
        Debug.Log(settings.musicVolume.ToString());
        Debug.Log(settings.soundVolume.ToString());
    }
}
