using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveOtherExitPoint : MonoBehaviour
{
    public Transform otherPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(otherPoint.position.x
                , other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            
        }else if (other.CompareTag("Monster"))
        {
            other.GetComponentInParent<NavMeshAgent>().Warp(new Vector3(otherPoint.position.x
                , other.gameObject.transform.position.y, other.gameObject.transform.position.z));
        }
    }
}
