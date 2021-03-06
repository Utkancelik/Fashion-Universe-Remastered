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
    public ReyonManager reyonManager;
    public bool isGiving;

    public delegate void OnMoneyCollectArea();
    public static event OnMoneyCollectArea OnMoneyCollect;

    public delegate void OnUnlockNewReyon();
    public static event OnUnlockNewReyon OnUnlockReyon;
    public static UnlockNewReyon unlockedArea;

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
            yield return new WaitForSeconds(0.5f);
            if (isGiving)
            {
                OnPurseGive();       
            }
            
            
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
            // ?ANTA ALMA ALANINDA ?SEM CIRCLE SLIDER IM A?IK OLACAK VE DOLDU?UNDA ?ANTA ALACA?IM
            if (TakingPurseCircleProgress())
            {
                OnPurseCollect();
            } 
            
        }
        if (other.gameObject.CompareTag("ReyonArea"))
        {
            isGiving = true;
            reyonManager = other.gameObject.GetComponent<ReyonManager>();
            reyonManager.purseNumText.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("UnlockArea"))
        {
            OnUnlockReyon();
            unlockedArea = other.gameObject.GetComponent<UnlockNewReyon>();
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
            reyonManager.purseNumText.gameObject.SetActive(false);
            //reyonManager = null;

        }
    }


}
