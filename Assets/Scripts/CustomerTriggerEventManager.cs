using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTriggerEventManager : MonoBehaviour
{
    public delegate void OnPurseTakeArea();
    public event OnPurseTakeArea OnPurseTake;
    public ReyonManager reyonManager;
    public bool isTaking;

    public delegate void OnPurseGiveArea();
    public event OnPurseGiveArea OnPurseGive;
    public static PayAreaManager payAreaManager;
    public bool isGiving;

    private void Start()
    {
        StartCoroutine(CollectOrGivingEnum());
    }
    IEnumerator CollectOrGivingEnum()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (isTaking)
            {
                OnPurseTake();
            }
            if (isGiving)
            {
                OnPurseGive();
            }          
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ReyonArea"))
        {
            isTaking = true;
            reyonManager = other.gameObject.GetComponent<ReyonManager>();
        }
        if (other.gameObject.CompareTag("PayArea"))
        {
            isGiving = true;
            payAreaManager = other.gameObject.GetComponent<PayAreaManager>();
        }     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExitDoor"))
        {
            CustomerGenerator customerGenerator = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CustomerGenerator>();
            customerGenerator.DieCustomer(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ReyonArea"))
        {
            isTaking = false;
            reyonManager.aimed = false;
            reyonManager = null;
        }
        if (other.gameObject.CompareTag("PayArea"))
        {
            isGiving = false;
        }
    }
}
