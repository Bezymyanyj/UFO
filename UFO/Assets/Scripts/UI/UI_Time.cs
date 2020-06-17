using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class UI_Time : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    [FormerlySerializedAs("currentTimeGUI")] public TextMeshProUGUI currentTimeGui;
    [FormerlySerializedAs("recordTimeGUI")] public TextMeshProUGUI recordTimeGui;

    private TMP_Text clock;
    private TMP_Text currentTime;
    private TMP_Text recordTime;
    private float levelTime; 
    private string testTime;
    private string levelMinute;
    private string levelSeconds;
    private int currentSeconds;
    private int minutes;
    private int seconds;

    private bool isPaused;
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Messenger.AddListener(GameEvent.Game_Paused, SetPause);
        Messenger.AddListener(GameEvent.Game_UnPaused, SetUnPause);
        Messenger.AddListener(GameEvent.Level_Complete, SetTime);
    }
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        Messenger.RemoveListener("Game_Paused", SetPause);
        Messenger.RemoveListener("Game_UnPaused", SetUnPause);
        Messenger.RemoveListener(GameEvent.Level_Complete, SetTime);
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        clock = tmp.GetComponent<TMP_Text>();
        currentTime = currentTimeGui.GetComponent<TMP_Text>();
        recordTime = recordTimeGui.GetComponent<TMP_Text>();
        
        string key = SceneManager.GetActiveScene().name;
        Debug.Log("Write current record" + key);
        Managers.Level.CurrentRecord = Managers.Level.timeLevel[key];
    }
    // Update is called once per frame
    void Update()
    {
        if(!isPaused){
            levelTime = Time.timeSinceLevelLoad;
            if(levelTime > currentSeconds){
                currentSeconds++;
                GetTimeInMinutes(currentSeconds);
                testTime = GetTime();
                clock.SetText(testTime);
            }
        }
    }

    private void GetTimeInMinutes(float sec){
        minutes = (int)Mathf.Floor(sec/60);
        seconds = (int) (sec - minutes*60);
    }
    private string GetTime(){
        levelMinute = minutes < 10 ? $"0{minutes}" : $"{minutes}";
        levelSeconds = seconds < 10 ? $"0{seconds}" : $"{seconds}";
        testTime = levelMinute + " : " + levelSeconds;
        return testTime;
    }

    private void SetPause(){
        isPaused = true;
    }

    private void SetUnPause(){
        isPaused = false;
    }

    private void SetTime()
    {
        currentTime.SetText("Level complete by: " + clock.text);
        Debug.Log("Record: " + Managers.Level.CurrentRecord);
        if (levelTime < Managers.Level.CurrentRecord)
        {
            Debug.Log("New Record");
            Managers.Level.CurrentRecord = levelTime;
            Managers.Level.timeLevel[SceneManager.GetActiveScene().name] = levelTime;
            recordTime.SetText("Record: " + clock.text);
        }
        else
        {
            Debug.Log("Old Record");
            float record = Managers.Level.CurrentRecord;
            GetTimeInMinutes(record);
            string recordText = GetTime();
            recordTime.SetText("Record: " + recordText);
        }
    }
}
