using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    GameObject monster;
    MonsterAI monsterAI;
    // Start is called before the first frame update
    void Start()
    {
        monsterAI = GetComponentInParent<MonsterAI>();
        monster = monsterAI.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (monsterAI.MonsterDeath())
            {
                AudioSingleton.Instance.PlayDieMonster();
                monster.SetActive(false);
                monsterAI.SetBigItem();
                PlaySingleton.Instance.DeathGameObject(monster);
            }
            else
            {
                AudioSingleton.Instance.PlayDiePlayer();
                other.gameObject.SetActive(false);
                PlaySingleton.Instance.SetState(GameState.PLAYERDIE);
                PlaySingleton.Instance.DeathGameObject(other.gameObject);
            }

        }
    }

}
