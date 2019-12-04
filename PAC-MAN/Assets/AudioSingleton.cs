using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSingleton : MonoBehaviour
{
    static AudioSingleton instance;
    public static AudioSingleton Instance { get => instance; }

    public AudioSource item;
    public AudioSource bigitem;
    public AudioSource bigitemTime;
    public AudioSource diePlayer;
    public AudioSource dieMonster;
    public AudioSource btn;
    public AudioSource clear;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void PlayItem() {
        if (item.isPlaying)
        {
            item.Stop();
        }
        item.Play();
    }

    public void PlayBigItem()
    {
        if (bigitem.isPlaying)
        {
            bigitem.Stop();
        }
        bigitem.Play();
    }
    public void PlayDiePlayer()
    {
        if (diePlayer.isPlaying)
        {
            diePlayer.Stop();
        }
        diePlayer.Play();
    }
    public void PlayDieMonster()
    {
        if (dieMonster.isPlaying)
        {
            dieMonster.Stop();
        }
        dieMonster.Play();
    }

    public void PlayBtn()
    {
        if (btn.isPlaying)
        {
            btn.Stop();
        }
        btn.Play();
    }
    public void PlayBigitemTime()
    {
        if (!bigitemTime.isPlaying)
        {
            bigitemTime.Play();
        }
        
    }
    public void StopBigitemTime()
    {
        if (bigitemTime.isPlaying)
        {
            bigitemTime.Stop();
        }

    }
    public void PlayClear()
    {
        if (clear.isPlaying)
        {
            clear.Stop();
        }
        clear.Play();
    }
}
