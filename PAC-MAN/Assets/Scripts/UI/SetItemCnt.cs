using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetItemCnt : MonoBehaviour
{
    int item;
    Text tx;
    // Start is called before the first frame update
    void Start()
    {
        item = PlaySingleton.Instance.GetItemCnt();
        tx = GetComponent<Text>();
        tx.text = "ITEM   " + item;
    }

    // Update is called once per frame
    void Update()
    {
        if (item != PlaySingleton.Instance.GetItemCnt())
        {
            item = PlaySingleton.Instance.GetItemCnt();
            tx.text = "ITEM   " + item;

            if (item == 0)
            {
                PlaySingleton.Instance.SetState(GameState.CLEAR);
            }
        }
    }
}
