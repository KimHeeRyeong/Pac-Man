using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    Vector3[] positions;
    Rigidbody rd;
    int i;
    int cnt;
    // Start is called before the first frame update
    void Start()
    {
        rd = this.GetComponent<Rigidbody>();
        i = 0;
        cnt = transform.childCount;
        positions = new Vector3[cnt];
        for(int i = 0; i < cnt; i++)
        {
            positions[i] = transform.GetChild(i).position;
        }
        for(int i = 0; i < cnt; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        transform.position = positions[i];
        StartCoroutine(Move());
    }
    private void FixedUpdate()
    {
        if(PlaySingleton.Instance.GetState() == GameState.PLAY)
        {
            if (rd.isKinematic)
            {
                rd.isKinematic = false;
            }
        }
        else
        {
            if (!rd.isKinematic)
            {
                rd.isKinematic = true;
            }
        }
    }
    IEnumerator Move() {
        yield return new WaitForSeconds(5);
        if (PlaySingleton.Instance.GetState() == GameState.PLAY)
        {
            i++;
            if (i >= cnt)
            {
                i = 0;
            }
            transform.position = positions[i];
        }
        StartCoroutine(Move());
    }
}
