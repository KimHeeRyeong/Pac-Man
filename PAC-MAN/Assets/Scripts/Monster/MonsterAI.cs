using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum MonsterStatus
{
    NONE,
    MOVING,
    TRACKING,
    AVOID,
}
public class MonsterAI : MonoBehaviour
{
    Transform player;
    MovingPointSet movingPoint;
    Transform[] randomPoint;
    NavMeshData navMesh;
    Vector3 lastVelocity;
    NavMeshAgent agent;
    MonsterStatus status;

    int randPointNum = -1;
    Vector3 randPos;
    int bigItem;// Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        movingPoint = GameObject.Find("MovingSpot").GetComponent<MovingPointSet>();
        agent = GetComponent<NavMeshAgent>();
        status = MonsterStatus.NONE;
        bigItem = 0;
        randomPoint = movingPoint.GetPoints();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (PlaySingleton.Instance.GetState() == GameState.PLAY) {
            StatusCase();
        } else if (PlaySingleton.Instance.GetState()==GameState.PLAYERDIE) {
            bigItem = PlaySingleton.Instance.GetBigItem();
            GetComponent<SetStartPos>().SetStart();
            agent.isStopped = true;
            status = MonsterStatus.NONE;
        }
        else if (status != MonsterStatus.NONE)
        {
            Pause();
            status = MonsterStatus.NONE;
        }
    }

    void StatusCase()
    {
        if (agent != null)
        {
            if (randPointNum != -1 && status != MonsterStatus.MOVING)
            {
                randPointNum = -1;
            }
            switch (status)
            {
                case MonsterStatus.NONE:
                    if (PlaySingleton.Instance.GetState() == GameState.PLAY)
                    {
                        Move();
                        status = MonsterStatus.MOVING;
                    }
                    break;
                case MonsterStatus.MOVING:
                    if (Vector3.Distance(randPos, transform.position) < 2 || randPointNum == -1)
                    {
                        GetRandomPos();
                    }
                    else
                    {
                        agent.SetDestination(randPos);
                    }
                    break;
                case MonsterStatus.TRACKING:
                    if (player.gameObject.activeSelf)
                    {
                        agent.SetDestination(player.position);
                    }
                    else
                    {
                        status = MonsterStatus.NONE;
                    }
                    break;
                case MonsterStatus.AVOID:
                    if(transform.position.x-player.position.x<0|| transform.position.y - player.position.y < 0)
                    {

                    }
                    Vector3 vec = (transform.position - player.position).normalized*2f;
                    if (vec.x < 0.1f && vec.x >= 0)
                    {
                        vec.x = 1;
                    }
                    else if (vec.x > -0.1f && vec.x < 0)
                    {
                        vec.x = -1;
                    }
                    if (vec.z < 0.1f && vec.z >= 0)
                    {
                        vec.z = 1;
                    }
                    else if (vec.z > -0.1f && vec.z < 0)
                    {
                        vec.z = -1;
                    }
                    agent.SetDestination(transform.position + vec);
                    break;
            }
        }
    }

    void GetRandomPos() {
        int max = randomPoint.Length;
        randPointNum = Random.Range(0, max - 1);
        randPos = randomPoint[randPointNum].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!PlaySingleton.Instance.GetBigItemTime()
                || PlaySingleton.Instance.GetBigItem() == bigItem)
            {
                status = MonsterStatus.TRACKING;
            }
            else
            {
                status = MonsterStatus.AVOID;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!PlaySingleton.Instance.GetBigItemTime()
                || PlaySingleton.Instance.GetBigItem() == bigItem)
            {
                status = MonsterStatus.TRACKING;
            }
            else
            {
                status = MonsterStatus.AVOID;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            status = MonsterStatus.NONE;
        }
    }

    public bool MonsterDeath() {
        if (status == MonsterStatus.AVOID)
        {
            return true;
        }
        return false;
    }
    public bool MonsterBlink() {
        if (bigItem != PlaySingleton.Instance.GetBigItem() && PlaySingleton.Instance.GetBigItemTime()) {
            return true;
        }
        return false;
    }
    public void SetBigItem() {
        status = MonsterStatus.NONE;
        bigItem = PlaySingleton.Instance.GetBigItem();
    }

    void Pause() {
        agent.isStopped = true;
        lastVelocity = agent.velocity;
        agent.velocity = Vector3.zero;
    }
    void Move()
    {
        agent.isStopped = false;
        agent.velocity = lastVelocity;
    }
}
