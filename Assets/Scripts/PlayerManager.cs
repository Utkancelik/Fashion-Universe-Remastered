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
            temp.transform.position = new Vector3(collectPoint.position.x + (float)purseList.Count/4, collectPoint.position.y, collectPoint.position.z);
            purseList.Add(temp);
        }      
    }
    public void GivePurse()
    {
        if (purseList.Count > 0 && PlayerTriggerEventManager.reyonManager.purseList.Count < 3)
        {
            PlayerTriggerEventManager.reyonManager.GetPurse();
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
