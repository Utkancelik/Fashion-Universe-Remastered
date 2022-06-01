using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{
    public List<GameObject> purseList = new List<GameObject>();
    public GameObject pursePrefab;
    public Transform collectPoint;
    public int purseLimit = 3;
    
    private void Start()
    {
    }
    private void OnEnable()
    {
        PlayerTriggerEventManager.OnPurseCollect += GetPurse;
        PlayerTriggerEventManager.OnPurseGive += GivePurse;
    }
    private void OnDisable()
    {
        PlayerTriggerEventManager.OnPurseCollect -= GetPurse;
        PlayerTriggerEventManager.OnPurseGive -= GivePurse;
    }
    private void GetPurse()
    {
        if (purseList.Count < purseLimit)
        {
            GameObject temp = Instantiate(pursePrefab, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, collectPoint.position.y - (float)purseList.Count /8, collectPoint.position.z);
            purseList.Add(temp);
        }      
    }
    public void GivePurse()
    {
        PlayerTriggerEventManager playerTriggerEventManager = GetComponent<PlayerTriggerEventManager>();
        if (purseList.Count > 0 && playerTriggerEventManager.reyonManager.purseList.Count < playerTriggerEventManager.reyonManager.purseLimit)
        {
            playerTriggerEventManager.reyonManager.GetPurse();
            RemoveLast();
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
