using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomMonster : MonoBehaviour
{
    public float trackingRadius;
    public float moveSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<SphereCollider>().radius = trackingRadius;
        GetComponent<NavMeshAgent>().speed = moveSpeed;
    }
}
