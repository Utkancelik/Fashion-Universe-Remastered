using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayAreaManager : MonoBehaviour
{
    public List<GameObject> moneyList = new List<GameObject>();
    public GameObject moneyPrefab;
    public Transform moneyPoint;


    public void GetMoney()
    {
        int rowCount = 5;
        GameObject temp = Instantiate(moneyPrefab);
        temp.transform.position = new Vector3(moneyPoint.position.x, moneyPoint.position.y + (float)moneyList.Count / 25, moneyPoint.position.z + moneyList.Count / rowCount);
        moneyList.Add(temp);
    }
    public void DestroyMoney()
    {
        foreach (var money in moneyList)
        {
            Destroy(money);
        }
        moneyList.Clear();
    }


}
