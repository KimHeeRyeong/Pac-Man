using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject play;
    public GameObject pause;
    public GameObject clear;
    public GameObject start;
    Image img;
    GameState state;
    // Start is called before the first frame update
    void Awake()
    {
        SetActiveFalse();
        img = GetComponent<Image>();
        img.enabled = true;
        SetActiveFalse();
        start.SetActive(true);
    }
    private void FixedUpdate()
    {
        if (state != PlaySingleton.Instance.GetState())
        {
            state = PlaySingleton.Instance.GetState();
            switch (state)
            {
                case GameState.CLEAR:
                    AudioSingleton.Instance.PlayClear();
                    img.enabled = true;
                    SetActiveFalse();
                    clear.SetActive(true);
                    break;
                case GameState.GAMEOVER:
                    img.enabled = true;
                    SetActiveFalse();
                    gameOver.SetActive(true);
                    break;
                
                case GameState.PAUSE:
                    img.enabled = true;
                    SetActiveFalse();
                    pause.SetActive(true);
                    break;
                case GameState.PLAYERDIE:
                    img.enabled = false;
                    SetActiveFalse();
                    break;
                case GameState.PLAY:
                    img.enabled = false;
                    SetActiveFalse();
                    play.SetActive(true);
                    break;
                case GameState.START:
                    img.enabled = true;
                    SetActiveFalse();
                    start.SetActive(true);
                    break;
            }
        }
    }
    void SetActiveFalse() {
        gameOver.SetActive(false);
        pause.SetActive(false);
        play.SetActive(false);
        clear.SetActive(false);
        start.SetActive(false);
    }
}
