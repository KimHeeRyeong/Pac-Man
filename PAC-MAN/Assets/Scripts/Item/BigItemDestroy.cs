using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigItemDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSingleton.Instance.PlayBigItem();
            PlaySingleton.Instance.SetBigItem();
            Destroy(gameObject);
        }
    }
}
