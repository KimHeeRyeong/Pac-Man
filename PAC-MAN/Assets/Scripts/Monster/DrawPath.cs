using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrawPath : MonoBehaviour
{
    public LineRenderer line;
    NavMeshPath path;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        path = agent.path;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        path = agent.path;
        int i = path.corners.Length;
        line.positionCount =i;
        i = 0;
        
        foreach(Vector3 cornor in path.corners)
        {
            line.SetPosition(i, cornor);
            i++;
        }
    }
}
