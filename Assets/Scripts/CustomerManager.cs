using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public List<GameObject> purseList = new List<GameObject>();
    public GameObject pursePrefab;
    public Transform purseCarryPoint;
    public int purseLimit = 1;
    private void OnEnable()
    {
        CustomerTriggerEventManager customerTriggerEventManager = GetComponent<CustomerTriggerEventManager>();
        customerTriggerEventManager.OnPurseTake += GetPurse;

        customerTriggerEventManager.OnPurseGive += GivePurse;
    }
    private void OnDisable()
    {
        CustomerTriggerEventManager customerTriggerEventManager = GetComponent<CustomerTriggerEventManager>();
        customerTriggerEventManager.OnPurseTake += GetPurse;

        customerTriggerEventManager.OnPurseGive -= GivePurse;
    }

    public void GetPurse()
    {
        if (purseList.Count < purseLimit && CustomerTriggerEventManager.reyonManager.purseList.Count > 0)
        {
            Debug.Log(gameObject.name);
            GameObject temp = Instantiate(pursePrefab, purseCarryPoint);
            temp.transform.position = new Vector3(purseCarryPoint.position.x + (float)purseList.Count / 4, purseCarryPoint.position.y, purseCarryPoint.position.z);
            purseList.Add(temp);
            CustomerTriggerEventManager.reyonManager.RemoveLast();
            CustomerTriggerEventManager.reyonManager.aimed = false;
            // objeyi reyondan aldýn artýk kasaya git ve satýn al
            CustomerMovement customerMovement = GetComponent<CustomerMovement>();
            customerMovement.MoveToBuy();
        }
    }
    public void GivePurse()
    {
        if (purseList.Count > 0)
        {
            CustomerTriggerEventManager.payAreaManager.GetMoney();
            RemoveLast();
            CustomerMovement customerMovement = GetComponent<CustomerMovement>();
            customerMovement.MoveToDie();
        }
    }

    public void RemoveLast()
    {
        if (purseList.Count > 0)
        {
            Destroy(purseList[purseList.Count - 1]);
            purseList.RemoveAt(purseList.Count - 1);
        }
    }

    
}
