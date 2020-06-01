using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Tutorial : MonoBehaviour
{
    public GameObject tutorialWindow;
    // Start is called before the first frame update
    void Start()
    {
        if(!Managers.Level.IsTutorialComplete){
            Time.timeScale = 0;
        }
        else{
            tutorialWindow.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        tutorialWindow.SetActive(false);
        Managers.Level.IsTutorialComplete = true;
        Time.timeScale = 1;
    }
}
