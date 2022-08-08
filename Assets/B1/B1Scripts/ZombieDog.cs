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
                // Ÿ�ٰ� �� ������Ʈ�� �Ÿ��� ���Ѵ�.
                //distance = Vector3.Distance(target.position, transform.position);
                // �Ÿ��� LookRadius�ݰ������ ������ awake�ִϸ��̼��� ����. �� slowwalk�Լ� 0.5���� ����
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
                    // �÷��̾ �߰��߿� stopRadis�ȿ� �����ԵǸ� ���
                    Player.player.survive = false;
                    Player.player.transform.GetComponent<Player>().enabled = false;
                    UIManager.UIcanvas.GetComponent<FadeController>().GameOverFadeOut();
                }
            }
        }
        else
        {
           // Debug.Log("���ư���");
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
        //Debug.Log("�߰� ����");
        DogAni.SetFloat("speed", 1);
        _AIStats = AIStatsKind.Chaseing;
        _Agent.speed = MaxSpeed;
    }
}
