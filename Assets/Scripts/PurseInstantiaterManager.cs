using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurseInstantiaterManager : MonoBehaviour
{
    /*
    public List<GameObject> purseList = new List<GameObject>();
    public GameObject pursePrefab;
    public Transform exitPoint;
    public bool isWorking;

    private void Start()
    {
        StartCoroutine(InstantiatePurse());
    }
    public void RemoveLast()
    {
        if (purseList.Count > 0)
        {
            Destroy(purseList[purseList.Count - 1]);
            purseList.RemoveAt(purseList.Count - 1);
        }
    }
    IEnumerator InstantiatePurse()
    {
        while (true)
        {
            if (isWorking)
            {
                GameObject temp = Instantiate(pursePrefab);
                temp.transform.position = exitPoint.position;
                purseList.Add(temp);
                if (purseList.Count == 1)
                {
                    isWorking = false;
                }
            }
            else if (purseList.Count < 1)
            {
                isWorking = true;
            }

            yield return new WaitForSeconds(1);
        }
    }
    */
}
