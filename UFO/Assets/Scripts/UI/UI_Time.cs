using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Time : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    private TMP_Text clock;
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
    }
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        Messenger.RemoveListener("Game_Paused", SetPause);
        Messenger.RemoveListener("Game_UnPaused", SetUnPause);
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        clock = tmp.GetComponent<TMP_Text>();
        //clock = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!isPaused){
            levelTime = Time.timeSinceLevelLoad;
            if(levelTime > currentSeconds){
                currentSeconds++;
                GetTimeInMinutes();
                GetTime();
                Debug.Log(testTime);
                clock.SetText(testTime);
            }
        }
    }

    private void GetTimeInMinutes(){
        minutes = (int)Mathf.Floor(currentSeconds/60);
        seconds = currentSeconds - minutes*60;
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
}
