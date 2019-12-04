using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigItemSetting : MonoBehaviour
{
    public GameObject bigItem;
    public Transform[] pos;
    // Start is called before the first frame update
    void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;//change seed
        for (int i = 0; i < 5; i++) {
            int rand= Random.Range(1,99);
            rand = (int)(rand * 0.02f)+(i*2);
            Vector3 randPos = new Vector3(pos[rand].position.x,1 ,pos[rand].position.z);
            Instantiate(bigItem, randPos, transform.rotation);
        }
    }
}
