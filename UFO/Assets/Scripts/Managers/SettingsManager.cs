﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class SettingsManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}
    
    [HideInInspector]
    public Settings settings = new Settings();

    [HideInInspector] public RecordCollection records = new RecordCollection();


    private const string JsonPath = "/settings.json";
    private const string RecordPath = "/records.json";
    
    public void Startup(){
        Debug.Log("Player manager starting...");

        if (File.Exists(Application.dataPath + JsonPath))
        {
            LoadSettings();
        }
        else
        {
            CreateSettings();
        }
        if(File.Exists(Application.dataPath + RecordPath))
            LoadRecords();
        else
        {
            CreateRecords();
        }

        //DebugSettings();
        status = ManagerStatus.Started;
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.Next_Level, WriteRecords);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.Next_Level, WriteRecords);
    }

    private void LoadSettings()
    {
        using (StreamReader stream = new StreamReader(Application.dataPath + JsonPath))
        {
            string json = stream.ReadToEnd();
            settings = JsonUtility.FromJson<Settings>(json);
        }
    }
    private void LoadRecords()
    {
        using (StreamReader stream = new StreamReader(Application.dataPath + RecordPath))
        {
            string json = stream.ReadToEnd();
            records = JsonUtility.FromJson<RecordCollection>(json);
        }
    }

    public void WriteSettings()
    {
        Managers.Control.WriteKeyCodes();
        settings.fullScreen = Screen.fullScreen;
        
        using (StreamWriter stream = new StreamWriter(Application.dataPath + JsonPath))
        {
            string json = JsonUtility.ToJson(settings);
            stream.Write(json);
        }
    }
    private void WriteRecords()
    {
        records.levelRecords[0].recordTime = Managers.Level.timeLevel["Level 1"];
        records.levelRecords[1].recordTime = Managers.Level.timeLevel["Level 2"];
        
        using (StreamWriter stream = new StreamWriter(Application.dataPath + RecordPath))
        {
            string json = JsonUtility.ToJson(records);
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
        
        using (StreamWriter stream = new StreamWriter(Application.dataPath + JsonPath))
        {
            string json = JsonUtility.ToJson(settings);
            stream.Write(json);
        }
    }

    private void CreateRecords()
    {
        LevelRecord[] levelRecord = new LevelRecord[2];
        levelRecord[0] = new LevelRecord() {levelName = "Level 1", recordTime = 666};
        levelRecord[1] = new LevelRecord() {levelName = "Level 2", recordTime = 666};

        records.collectionName = "Records";
        records.levelRecords = levelRecord;
        //
        // string playerToJson = JsonHelper.ToJson(levelRecord, true);
        // Debug.Log(playerToJson);
        using (StreamWriter stream = new StreamWriter(Application.dataPath + RecordPath))
        {
            string json = JsonUtility.ToJson(records);
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
        Debug.Log(settings.musicVolume.ToString(CultureInfo.InvariantCulture));
        Debug.Log(settings.soundVolume.ToString(CultureInfo.InvariantCulture));
    }
}
