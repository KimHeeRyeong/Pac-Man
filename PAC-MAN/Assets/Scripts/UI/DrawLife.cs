using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLife : MonoBehaviour
{
    public GameObject lifePref;
    GameObject[] life;
    int lifeCnt;
    void Start()
    {
        lifeCnt = PlaySingleton.Instance.GetLife();
        life = new GameObject[lifeCnt];
        for(int i = 0; i < lifeCnt; i++)
        {
            life[i]=Instantiate(lifePref, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeCnt != PlaySingleton.Instance.GetLife()) {
            lifeCnt--;
            if (lifeCnt > 0)
            {
                Destroy(life[lifeCnt - 1]);
            }
            
        }
    }
}
