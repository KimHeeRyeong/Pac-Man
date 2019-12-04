using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState{
    START,
    PLAY,
    PLAYERDIE,
    PAUSE,
    GAMEOVER,
    CLEAR,
}
public class PlaySingleton : MonoBehaviour
{
    static PlaySingleton instance;
    public static PlaySingleton Instance { get => instance; }
    Coroutine preItemTime;

    GameState state;
    int bigItem;
    int life;
    int score;
    int itemCnt;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log(gameObject.name + "//" + name + "don't instance!=null");
            Destroy(gameObject);
            return;
        }
        instance = this;
        //initialize
        state = GameState.START;
        life = 3;
        score = 0;
        itemCnt = 0;
        bigItem = 0;//if player get bigItem ->+1, big item time 이 끝나면 음수로 저장(-bigItem)
    }
    private void Start()
    {
        Screen.SetResolution(640, 480, false);
    }
    //about itemCnt
    public void AddItemCnt(int val)
    {
        itemCnt += val;
    }
    public int GetItemCnt() {
        return itemCnt;
    }
    public void ReduceItemCnt() {
        score++;
        itemCnt--;
    }

    //about state
    public void SetState(GameState set) {
        state = set;
    }
    public GameState GetState() {
        return state;
    }
    
    //about bigItem
    public void SetBigItem()
    {
        Debug.Log("Start : BigItemTime");
        AudioSingleton.Instance.PlayBigitemTime();
        if (preItemTime != null)
        {
            StopCoroutine(preItemTime);
        }
        if (bigItem < 0)
        {
            bigItem = -bigItem;
        }
        bigItem++;
        preItemTime = StartCoroutine(BigItemTime());
    }
    IEnumerator BigItemTime()
    {
        yield return new WaitForSeconds(10f);
        bigItem = -bigItem;
        Debug.Log("End : bigItemTime");
        AudioSingleton.Instance.StopBigitemTime();
    }
    public int GetBigItem()
    {
        return bigItem;
    }
    public bool GetBigItemTime()
    {
        if (bigItem > 0)
        {
            return true;
        }
        return false;
    }

    //about life
    public void DeathGameObject(GameObject obj) {
        if (obj.CompareTag("Player"))
        {
            life--;
            if(life == 0)
            {
                state = GameState.GAMEOVER;
            }
            else
            {
                StartCoroutine(RevivePlayer(obj));
            }
        }
        else//Death monster
        {
            score += 100;
            StartCoroutine(Revive(obj,3));
        }
    }
    IEnumerator Revive(GameObject obj,float time) {
        obj.GetComponent<SetStartPos>().SetStart();
        yield return new WaitForSeconds(time);
        obj.SetActive(true);
    }
    IEnumerator RevivePlayer(GameObject obj)
    {
        obj.GetComponent<SetStartPos>().SetStart();
        StopCoroutine(BigItemTime());
        if (bigItem < 0)
        {
            bigItem -= bigItem;
        }
        yield return new WaitForSeconds(1);
        state = GameState.PLAY;
        obj.SetActive(true);
    }
    public int GetLife() {
        return life;
    }

    public int GetScore() {
        return score;
    }
}
