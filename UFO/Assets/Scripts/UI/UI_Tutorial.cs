using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Tutorial : MonoBehaviour
{
    public GameObject tutorialWindow;

    public TextMeshProUGUI pushUpText;

    public TextMeshProUGUI pushLeftText;

    public TextMeshProUGUI pushRightText;

    public TextMeshProUGUI pushDownText;

    private TMP_Text pushUp;

    private TMP_Text pushLeft;

    private TMP_Text pushRight;

    private TMP_Text pushDown;

    private AudioSource click;

    private void Awake()
    {
        pushUp = pushUpText.GetComponent<TMP_Text>();
        pushLeft = pushLeftText.GetComponent<TMP_Text>();
        pushRight = pushRightText.GetComponent<TMP_Text>();
        pushDown = pushDownText.GetComponent<TMP_Text>();
        click = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!Managers.Level.IsTutorialComplete){
            Time.timeScale = 0;
            Messenger.Broadcast(GameEvent.GamePaused);
            pushUp.text = $"Press: {Managers.Settings.settings.pushUp}";
            pushLeft.text = $"Press: {Managers.Settings.settings.pushLeft}";
            pushRight.text = $"Press: {Managers.Settings.settings.pushRight}";
            pushDown.text = $"Press: {Managers.Settings.settings.pushDown}";
        }
        else{
            tutorialWindow.SetActive(false);
            
        }

    }

    public void StartGame(){
        click.Play();
        tutorialWindow.SetActive(false);
        Managers.Level.IsTutorialComplete = true;
        Time.timeScale = 1;
        Messenger.Broadcast(GameEvent.GameUnPaused);
    }
}
