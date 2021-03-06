using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<GameObject> reyonList = new List<GameObject> ();
    public int reyonAmount;
    public Transform movePoint;
    public bool iHaveTarget,iHaveUrun;
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator> ();
        reyonAmount = GameObject.FindGameObjectsWithTag("ReyonArea").Length;
        for (int i = 0; i < reyonAmount; i++)
        {
            reyonList.Add(GameObject.FindGameObjectsWithTag("ReyonArea")[i]);
        }
    }

    private void Update()
    {
        FindTargetAndGo();
    }

    public void MoveToBuy()
    {
        GameObject kasa = GameObject.FindGameObjectWithTag("PayArea");
        agent.SetDestination(kasa.transform.position);
        animator.SetBool("isWalking", true);
    }

    public void MoveToDie()
    {
        GameObject door = GameObject.FindGameObjectWithTag("ExitDoor");
        agent.SetDestination(door.transform.position);
        animator.SetBool("isWalking", true);
    }

    public void FindTargetAndGo()
    {
        if (!iHaveTarget)
        {
            int rand = Random.Range(0, reyonAmount);
            if (reyonList[rand].GetComponent<ReyonManager>().purseList.Count > 0 && !reyonList[rand].GetComponent<ReyonManager>().aimed)
            {
                iHaveTarget = true;
                reyonList[rand].GetComponent<ReyonManager>().aimed = true;
                agent.SetDestination(reyonList[rand].transform.position);
                animator.SetBool("isWalking", true);
            }
        }
    }
}
