using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReyonManager : MonoBehaviour
{
    public List<GameObject> purseList = new List<GameObject>();
    public GameObject pursePrefab;
    public Transform reyonPoint;
    public int purseLimit = 4;
    public bool aimed;
    public Text purseNumText;
    private void Start()
    {
        GetPurse();
        GetPurse();
        GetPurse();
        GetPurse();
        purseNumText.gameObject.SetActive(false);
    }
    public void GetPurse()
    {          
        GameObject temp = Instantiate(pursePrefab, reyonPoint);
        temp.transform.position = new Vector3(reyonPoint.position.x - (float)purseList.Count / 8f, reyonPoint.position.y, reyonPoint.position.z + (float)purseList.Count / 4);
        //temp.transform.position = reyonPoint.position +  new Vector3( (float)purseList.Count / 5, 0, -(float)purseList.Count / 5 );
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
