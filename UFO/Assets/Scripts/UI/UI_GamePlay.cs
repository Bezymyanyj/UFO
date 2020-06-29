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
    public GameObject pointer;

    public float scale = 1;

    /// <summary>
    /// Максимальная "мощность" слайдера
    /// </summary>
    /// <param name="max"></param>
    public void SetMaxValueOfSlider(float max)
    {
        sliderLeftEngine.maxValue = max;
        sliderRightEngine.maxValue = max;
    }

    /// <summary>
    /// Уровень правого двигателя(Слайдер)
    /// </summary>
    /// <param name="force">Мощность двигателя</param>
    public void SetValueRightEngine(float force) => sliderRightEngine.value = force;

    /// <summary>
    /// Уровень левого двигателя(Слайдер)
    /// </summary>
    /// <param name="force">Мощность двигателя</param>
    public void SetValueLeftEngine(float force) => sliderLeftEngine.value = force;

    /// <summary>
    /// Показыввает высотууровня в %
    /// </summary>
    /// <param name="high"> текущая высота</param>
    public void SetValueAltimeter(float high)
    {
        float currentHigh = Mathf.Abs(high - bottomPoint.position.y);
        sliderAltimeter.value = currentHigh / (topPoint.position.y + Mathf.Abs(bottomPoint.position.y)) * 100;
    }

    /// <summary>
    /// Направление дважения тарелки
    /// </summary>
    /// <param name="angle">Угол поворота</param>
    public void RotateDirectionPointer(float angle)
    {
        Quaternion pointer = directionPointer.transform.rotation;
        directionPointer.transform.rotation = Quaternion.Euler(pointer.eulerAngles.x, pointer.eulerAngles.y, angle);
        
    }

    public void DirectionUfo(Vector3 Ufo)
    {
        Vector3 pointerPosition = Ufo;

        RectTransform pointRt = (RectTransform) pointer.transform;

        pointRt.anchoredPosition = pointerPosition * scale;

        RectTransform arrowRT = (RectTransform) directionPointer.transform;

        Vector3 direction = (pointRt.position - arrowRT.position).normalized;
        
        float angle = Mathf.Atan2(pointRt.position.y-arrowRT.position.y, pointRt.position.x-arrowRT.position.x)*180 / Mathf.PI;

        arrowRT.rotation = Quaternion.Euler(0,0,angle - 90);
    }
}

