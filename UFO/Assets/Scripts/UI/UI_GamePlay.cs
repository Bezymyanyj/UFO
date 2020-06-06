using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class UI_GamePlay : MonoBehaviour
{
    public Slider sliderRightEngine;
    public Slider sliderLeftEngine;
    public Slider sliderAltimeter;

    public Transform bottomPoint;
    public Transform topPoint;

    public GameObject directionPointer;

    
    
    public void SetMaxValueOfSlider(float max)
    {
        sliderLeftEngine.maxValue = max;
        sliderRightEngine.maxValue = max;
    }

    public void SetValueRightEngine(float force)
    {
        sliderRightEngine.value = force;
    }

    public void SetValueLeftEngine(float force)
    {
        sliderLeftEngine.value = force;
    }

    public void SetValueAltimeter(float high)
    {
        float currentHigh = Mathf.Abs(high - bottomPoint.position.y);
        sliderAltimeter.value = currentHigh / (topPoint.position.y + Mathf.Abs(bottomPoint.position.y)) * 100;
    }

    public void RotateDirectionPointer(float angle)
    {
        Quaternion pointer = directionPointer.transform.rotation;
        directionPointer.transform.rotation = Quaternion.Euler(pointer.x, pointer.y, angle);
    }
}

