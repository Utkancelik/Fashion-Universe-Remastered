using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyManager : MonoBehaviour
{
    public int totalMoney;
    public Text moneyText;
    private void OnEnable()
    {
        PlayerTriggerEventManager.OnMoneyCollect += IncreaseMoney;
        PlayerTriggerEventManager.OnUnlockReyon += UnlockReyon;
    }

    private void OnDisable()
    {
        PlayerTriggerEventManager.OnMoneyCollect -= IncreaseMoney;
        PlayerTriggerEventManager.OnUnlockReyon -= UnlockReyon;
    }

    private void Update()
    {
        moneyText.text = totalMoney.ToString();

    }

    public void IncreaseMoney()
    {
        PayAreaManager payAreaManager = GetComponentInParent<PayAreaManager>();
        int moneyAmount = payAreaManager.moneyList.Count;
        totalMoney += moneyAmount * 5;
        payAreaManager.DestroyMoney();
    }

    public void UnlockReyon()
    {
        if (PlayerTriggerEventManager.unlockedArea != null && PlayerTriggerEventManager.unlockedArea.enabled)
        {
            Debug.Log("TEST");
            if (totalMoney >= 1)
            {
                PlayerTriggerEventManager.unlockedArea.Unlock(1);
                totalMoney -= 1;
            }
            
        }
    }
}
