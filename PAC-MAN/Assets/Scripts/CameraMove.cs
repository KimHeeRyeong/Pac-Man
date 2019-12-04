using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    int moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.width,(Screen.width*3)/4, true);
        transform.position = new Vector3(0, 30, player.position.z) ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlaySingleton.Instance.GetState()==GameState.PLAY)
        {
            if (player.position.z < 18f && player.position.z > -18f)
            {
                float minusZ = player.position.z - transform.position.z;
                if (Mathf.Abs(minusZ) > moveSpeed*Time.deltaTime)
                {
                    transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime*minusZ);
                }
                else
                {
                    transform.position = new Vector3(0, 30, player.position.z);
                }
            }
        }
    }
}
