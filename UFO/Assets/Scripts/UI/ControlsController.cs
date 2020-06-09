using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlsController : MonoBehaviour
{
    public ButtonManagerBasic[] controlButtons;
    public GameObject optionsWindow;
    
    private bool isActive;
    private string currentKey;
    private int currentIndex;

    private void Start()
    {
        StartCoroutine(SetButtonsText());
    }

    public void ActivateSetKeyCode(string key)
    {
        currentKey = key;
        isActive = true;
        optionsWindow.GetComponent<CanvasGroup>().interactable = false;
    }

    public void SendButtonIndex(int index)
    {
        currentIndex = index;
        controlButtons[currentIndex].normalText.text = "";
    }
    
    

    void OnGUI()
    {
        if (isActive)
        {
            Event e = Event.current;
            if (e.keyCode == KeyCode.Escape)
            {
                isActive = false;
                optionsWindow.GetComponent<CanvasGroup>().interactable = true;
            }
            else if (e.isKey)
            {
                //Debug.Log("Detected key code: " + e.keyCode);
                Managers.Control.KeyCodes[currentKey] = e.keyCode;
                controlButtons[currentIndex].normalText.text = e.keyCode.ToString();
                isActive = false;
                optionsWindow.GetComponent<CanvasGroup>().interactable = true;
            }
        }
    }
    
    private IEnumerator SetButtonsText()
    {
        yield return  new WaitForSeconds(0.1f);
        
        //controlButtons[0].normalText.text = Managers.Control.KeyCodes["PushUp"].ToString();
        controlButtons[0].buttonText = Managers.Control.KeyCodes["PushUp"].ToString();
        //controlButtons[1].normalText.text = Managers.Control.KeyCodes["PushLeft"].ToString();
        controlButtons[1].buttonText = Managers.Control.KeyCodes["PushLeft"].ToString();
        //controlButtons[2].normalText.text = Managers.Control.KeyCodes["PushRight"].ToString();
        controlButtons[2].buttonText = Managers.Control.KeyCodes["PushRight"].ToString();
        //controlButtons[3].normalText.text = Managers.Control.KeyCodes["PushDown"].ToString();
        controlButtons[3].buttonText = Managers.Control.KeyCodes["PushDown"].ToString();
    }

    
}
