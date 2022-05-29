using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggerEventManager : MonoBehaviour
{
    public delegate void OnPurseCollectArea();
    public static event OnPurseCollectArea OnPurseCollect;
    public bool isCollecting;

    public delegate void OnReyonArea();
    public static event OnReyonArea OnPurseGive;
    public static ReyonManager reyonManager;
    public bool isGiving;

    public delegate void OnMoneyCollectArea();
    public static event OnMoneyCollectArea OnMoneyCollect;

    public Slider circleSlider;
    private void Start()
    {
        circleSlider.value = 0;
        circleSlider.gameObject.SetActive(false);
        StartCoroutine(CollectOrGivingEnum());
    }
    IEnumerator CollectOrGivingEnum()
    {
        while (true)
        {
            /*
            if (isCollecting)
            {
                
            */
            if (isGiving)
            {
                OnPurseGive();       
            }
            yield return new WaitForSeconds(1);
            
        }
    }
    public bool TakingPurseCircleProgress()
    {
        if (GetComponent<PlayerManager>().purseList.Count < GetComponent<PlayerManager>().purseLimit)
        {
            circleSlider.gameObject.SetActive(true);
            circleSlider.value += Time.deltaTime;
            if (circleSlider.value == circleSlider.maxValue)
            {
                circleSlider.value = 0;
                return true;
            }
            else
            {

                return false;
            }
        }
        else
        {
            circleSlider.value = 0;
            circleSlider.gameObject.SetActive(false);
            return false;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PurseCollectArea"))
        {
            // ÇANTA ALMA ALANINDA ÝSEM CIRCLE SLIDER IM AÇIK OLACAK VE DOLDUÐUNDA ÇANTA ALACAÐIM
            if (TakingPurseCircleProgress())
            {
                OnPurseCollect();
            } 
            
        }
        if (other.gameObject.CompareTag("ReyonArea"))
        {
            isGiving = true;
            reyonManager = other.gameObject.GetComponent<ReyonManager>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TakeMoneyArea"))
        {
            OnMoneyCollect();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PurseCollectArea"))
        {
            isCollecting = false;
            circleSlider.value = 0;
            circleSlider.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("ReyonArea"))
        {
            isGiving = false;
            reyonManager = null;

        }
    }


}
