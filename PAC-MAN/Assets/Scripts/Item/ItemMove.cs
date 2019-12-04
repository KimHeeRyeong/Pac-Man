using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    void Update()
    {
        if(PlaySingleton.Instance.GetState() == GameState.PLAY)
        transform.Rotate(Time.deltaTime * 100,Time.deltaTime * 75,Time.deltaTime * 56);
    }
}
