using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            AudioSingleton.Instance.PlayItem();
            PlaySingleton.Instance.ReduceItemCnt();
            Destroy(gameObject);
        }
    }
}
