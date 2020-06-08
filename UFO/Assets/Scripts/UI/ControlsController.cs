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
    
    public void ActivateSetKeyCode(string key)
    {
        currentKey = key;
        isActive = true;
        optionsWindow.GetComponent<CanvasGroup>().interactable = false;
    }

    public void SendButtonIndex(int index)
    {
        currentIndex = index;
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
}
