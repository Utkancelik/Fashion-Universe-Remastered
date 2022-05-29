using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    public GameObject customerPrefab;
    public List<GameObject> customerList = new List<GameObject>();
    public Transform spawnPoint;
    private void Start()
    {
        StartCoroutine(GenerateCustomer());
    }
    IEnumerator GenerateCustomer()
    {
        while (true) 
        {
            if (customerList.Count < 3)
            {
                GameObject temp = Instantiate(customerPrefab);
                temp.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.z, spawnPoint.position.z);
                customerList.Add(temp);
            }
            yield return new WaitForSeconds(1);
        }
        
    }
}
