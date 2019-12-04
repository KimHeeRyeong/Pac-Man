using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPointSet : MonoBehaviour
{
    Transform[] points;
    // Start is called before the first frame update
    void Awake()
    {
        int childCnt = transform.childCount;
        points = new Transform[childCnt];

        for(int i = 0; i < childCnt; i++)
        {
            points[i] = gameObject.transform.GetChild(i);
        }
    }

    public Transform[] GetPoints() {
        return points;
    }
}
