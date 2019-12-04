using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIBtnClick : MonoBehaviour
{
    public void ClickStart() {
        AudioSingleton.Instance.PlayBtn();
        PlaySingleton.Instance.SetState(GameState.PLAY);
    }

    public void ClickExit() {
        AudioSingleton.Instance.PlayBtn();
        Application.Quit();
    }

    public void ClickPause() {
        AudioSingleton.Instance.PlayBtn();
        PlaySingleton.Instance.SetState(GameState.PAUSE);
    }

    public void ClickUnPause() {
        AudioSingleton.Instance.PlayBtn();
        PlaySingleton.Instance.SetState(GameState.PLAY);
    }
}
