using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    public float speed = 2;
    Text tx;
    bool fade;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        tx = this.GetComponent<Text>();
        color = tx.color;
        fade = true;
    }

    private void Update()
    {
        if (fade)
        {
            color.a -= speed*Time.deltaTime;
            tx.color = color;
            if (color.a <= 0)
            {
                fade = false;
            }
        }
        else
        {
            color.a += speed * Time.deltaTime;
            tx.color = color;
            if (color.a >= 1)
            {
                fade = true;
            }
        }
    }
}
