using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReyonManager : MonoBehaviour
{
    public List<GameObject> purseList = new List<GameObject>();
    public GameObject pursePrefab;
    public Transform reyonPoint;
    public int purseLimit = 3;
    public bool aimed;
    public Text purseNumText;
    private void Start()
    {
        purseNumText.gameObject.SetActive(false);
    }
    public void GetPurse()
    {          
        GameObject temp = Instantiate(pursePrefab, reyonPoint);
        temp.transform.position = new Vector3(reyonPoint.position.x, reyonPoint.position.y, reyonPoint.position.z + (float)purseList.Count / 2);
        purseList.Add(temp);
    }
    public void RemoveLast()
    {
        if (purseList.Count > 0)
        {
            Destroy(purseList[purseList.Count - 1]);
            purseList.RemoveAt(purseList.Count - 1);
        }
    }

    private void Update()
    {
        purseNumText.text = purseList.Count.ToString() + "/" + purseLimit;
    }


}
