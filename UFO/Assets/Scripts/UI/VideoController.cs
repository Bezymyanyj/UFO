using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    private int _currentResolutionIndex;
    
    public CustomDropdown ResolutionDropdown;
    
    
    public void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    
    public void SetResolution(int resolutionIndex)
    {
        int width = int.Parse(ResolutionDropdown.dropdownItems[resolutionIndex].itemName.Split('x')[0]);
        int height = int.Parse(ResolutionDropdown.dropdownItems[resolutionIndex].itemName.Split('x')[1]);
        
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
