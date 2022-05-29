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
    }

    private void OnDisable()
    {
        PlayerTriggerEventManager.OnMoneyCollect -= IncreaseMoney;
    }

    public void IncreaseMoney()
    {
        PayAreaManager payAreaManager = GetComponentInParent<PayAreaManager>();
        int moneyAmount = payAreaManager.moneyList.Count;
        totalMoney += moneyAmount * 5;
        moneyText.text = totalMoney.ToString();
        payAreaManager.DestroyMoney();
    }
}
