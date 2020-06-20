using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status {get; private set;}

    public Dictionary<string, KeyCode> KeyCodes = new Dictionary<string, KeyCode>()
    {
        {"PushUp", KeyCode.W},
        {"PushDown", KeyCode.S},
        {"PushLeft", KeyCode.A},
        {"PushRight", KeyCode.D}
    };

    private Settings settings;

    public void Startup(){
        Debug.Log("Player manager starting...");

        StartCoroutine(LoadKeyCodes());
        
        Status = ManagerStatus.Started;
    }

    /// <summary>
    /// Загружаем управление  пользователя из файла
    /// Загружаем чуть позже так как данные берем из другога манеджера и он моэет загрузится раньше.
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadKeyCodes()
    {
        yield return new WaitForSeconds(0.05f);
        settings = Managers.Settings.settings;
        
        KeyCodes["PushUp"] = (KeyCode) Enum.Parse(typeof(KeyCode), settings.pushUp);
        KeyCodes["PushDown"] = (KeyCode) Enum.Parse(typeof(KeyCode), settings.pushDown);
        KeyCodes["PushLeft"] = (KeyCode) Enum.Parse(typeof(KeyCode), settings.pushLeft);
        KeyCodes["PushRight"] = (KeyCode) Enum.Parse(typeof(KeyCode), settings.pushRight);
    }
    
    /// <summary>
    /// Выводим имя кнопок контроля в интерфейс настроек
    /// </summary>
    public void WriteKeyCodes()
    {
        settings.pushUp = KeyCodes["PushUp"].ToString();
        settings.pushDown = KeyCodes["PushDown"].ToString();
        settings.pushLeft = KeyCodes["PushLeft"].ToString();
        settings.pushRight = KeyCodes["PushRight"].ToString();
    }
}
