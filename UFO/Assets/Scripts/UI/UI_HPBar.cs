using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPBar : MonoBehaviour
{
    public CanvasGroup hpBarGroup;
    public Slider hpBar;
    
    private void Awake()
    {
        Messenger.AddListener(GameEvent.EnemyCollision, ChangeHealth);
        Messenger.AddListener(GameEvent.LevelFailed, SetHealth);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.EnemyCollision, ChangeHealth);
        Messenger.RemoveListener(GameEvent.LevelFailed, SetHealth);
    }

    /// <summary>
    /// Востанавливаем hpBar на рестарте
    /// </summary>
    private void SetHealth() => hpBar.value = hpBar.maxValue;

    #region Изменение HP
    
    private void ChangeHealth()
    {
        //hpBar.value -= (float)Managers.Player.value;
        hpBar.value -= 25;
        StartCoroutine(ShowHpBar());
    }

    /// <summary>
    /// Показываем HP не большой промежуток времени
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowHpBar()
    {
        hpBarGroup.alpha = 1;
        yield return new WaitForSeconds(1);
        hpBarGroup.alpha = 0;
    }
    #endregion
}
