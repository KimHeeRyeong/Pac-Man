using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItems : MonoBehaviour
{
    public GameObject itemPref;
    LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        int pointCnt = lr.positionCount;
        Vector3 prePos = lr.GetPosition(0);
        for(int i = 0; i < pointCnt; i++)
        {
            Vector3 nowPos = lr.GetPosition(i);
            int middleCnt = (int)(Vector3.Distance(prePos, nowPos) * 0.5f);
            for(int j = 0; j < middleCnt; j++)
            {
                float percent = (float)(j+1)/(float)middleCnt;
               Vector3 insPos = Vector3.Lerp(prePos, nowPos, percent);
                Instantiate(itemPref, insPos, transform.rotation);
            }
            Instantiate(itemPref, lr.GetPosition(i), transform.rotation);
            PlaySingleton.Instance.AddItemCnt(middleCnt + 1);
            prePos = nowPos;
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
