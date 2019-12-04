using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartPos : MonoBehaviour
{
    public Vector3 startPos;
    private void Start()
    {
        transform.position = startPos;
    }
    public void SetStart() {
        transform.position = startPos;
    }
}
