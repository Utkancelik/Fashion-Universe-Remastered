using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnlockNewReyon : MonoBehaviour
{
    public Text costText;
    public GameObject transparentReyon, unlockedReyon;
    public float cost, currentMoney, progress;
    private void Update()
    {
        costText.text = (cost - currentMoney).ToString();
    }
    public void Unlock(int increaseAmount)
    {
        currentMoney += increaseAmount;
        progress = currentMoney / cost;
        
        if (progress >= 1)
        {
            transparentReyon.SetActive(false);
            unlockedReyon.SetActive(true);
            this.enabled = false;
        }
    }
}
