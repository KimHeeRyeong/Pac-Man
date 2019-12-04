using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    int score;
    Text tx;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        tx = GetComponent<Text>();
        tx.text =""+ score;
    }

    // Update is called once per frame
    void Update()
    {
        if(score!= PlaySingleton.Instance.GetScore())
        {
            score = PlaySingleton.Instance.GetScore();
            tx.text = ""+score;
        }
    }
}
