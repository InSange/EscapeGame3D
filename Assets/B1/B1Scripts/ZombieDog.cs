using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum AIStatsKind { idle, Active, Chaseing }

[RequireComponent(typeof(NavMeshAgent))]

public class ZombieDog : MonoBehaviour
{
    public float LookRadius = 10f;
    public float stopRadis = 2f;
    public float MaxSpeed = 5f;
    public Transform target;
    private NavMeshAgent _Agent;
    public Animator DogAni;
    private AIStatsKind _AIStats;
    public bool isChaseing;
    public GameObject backPoint;
    float distance;

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopRadis);

    }
    private void Awake()
    {
        _Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
        //Debug.Log(distance);
        if (distance <= LookRadius && Player.player.silence == false)
        {
            if (_AIStats == AIStatsKind.idle)
            {
                // 타겟과 이 오브젝트의 거리를 구한다.
                //distance = Vector3.Distance(target.position, transform.position);
                // 거리가 LookRadius반경안으로 들어오면 awake애니메이션을 실행. 후 slowwalk함수 0.5초후 실행
                if (distance <= LookRadius)
                {
                    DogAni.SetBool("awake", true);
                    Invoke("_SlowWalk", 0.5f);
                    _AIStats = AIStatsKind.Active;
                    _Agent.speed = 0.5f;
                }

            }


            if (_AIStats == AIStatsKind.Chaseing)
            {
                _Agent.SetDestination(target.position);
                DogAni.SetFloat("speed", _Agent.velocity.magnitude);
                //Debug.Log(_Agent.velocity.magnitude);
                //distance = Vector3.Distance(target.position, transform.position);
                if (distance <= stopRadis && Player.player.survive == true)
                {
                    // 플레이어가 추격중에 stopRadis안에 들어오게되면 사망
                    Player.player.survive = false;
                    Player.player.transform.GetComponent<Player>().enabled = false;
                    UIManager.UIcanvas.GetComponent<FadeController>().GameOverFadeOut();
                }
            }
        }
        else
        {
           // Debug.Log("돌아간다");
            if (_AIStats == AIStatsKind.Chaseing)
            {
                float backdistance = Vector3.Distance(transform.position, backPoint.transform.position);
                _Agent.SetDestination(backPoint.transform.position);
                DogAni.SetFloat("speed", _Agent.velocity.magnitude);
            }
        }
    }

    void _SlowWalk()
    {
        SoundManager.SM.PlaySound("Dog");
        _Agent.SetDestination(target.position);
        DogAni.SetFloat("speed", 0.5f);
        Invoke("_ChasePlayer", 3.0f);


    }

    void _ChasePlayer()
    {
        //Debug.Log("추격 시작");
        DogAni.SetFloat("speed", 1);
        _AIStats = AIStatsKind.Chaseing;
        _Agent.speed = MaxSpeed;
    }
}
