using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkColor : MonoBehaviour
{
    Light point;
    Color original;
    MonsterAI monster;
    bool flare;
    private void Start()
    {
        point = GetComponent<Light>();
        original = point.color;
        flare = true;
        monster = GetComponentInParent<MonsterAI>();
    }
    private void FixedUpdate()
    {
        if (PlaySingleton.Instance.GetState()== GameState.PLAY)
        {
            if (monster.MonsterBlink())
            {
                if (point.intensity != 6)
                {
                    point.intensity = 6;
                }
                ChangeColor();
            }
            else if (point.color != original)
            {
                if (point.intensity != 3)
                {
                    point.intensity = 3;
                }
                point.color = original;
            }
        }
    }
    public void ChangeColor()
    {
        if (flare)
        {
            point.color += new Color(0.1f, 0, 0);
            if (point.color.r >= 1)
            {
                flare = false;
            }
        }
        else {
            point.color -= new Color(0.1f, 0, 0);
            if (point.color.r <= 0)
            {
                flare = true;
            }
        }
    }
}
