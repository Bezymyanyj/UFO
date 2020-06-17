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
        Messenger.AddListener(GameEvent.Level_Failed, SetHealth);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.EnemyCollision, ChangeHealth);
        Messenger.RemoveListener(GameEvent.Level_Failed, SetHealth);
    }

    private void SetHealth()
    {
        hpBar.value = hpBar.maxValue;
    }

    private void ChangeHealth()
    {
        //hpBar.value -= (float)Managers.Player.value;
        hpBar.value -= 25;
        StartCoroutine(ShowHpBar());
    }

    private IEnumerator ShowHpBar()
    {
        hpBarGroup.alpha = 1;
        yield return new WaitForSeconds(1);
        hpBarGroup.alpha = 0;
    }
}
