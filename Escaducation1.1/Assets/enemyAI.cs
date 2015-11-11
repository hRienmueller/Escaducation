using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseWaitTime = 5f;
    public float patrolWaitTime = 1f;
    public Transform[] patrolWayPoints;

    private EnemySight enemySight;
    private NavMeshAgent nav;
    private Transform player;
    private LastPlayerSighting lastPlayerSighting;
    private float chaseTimer;
    private float patrolTimer;
    private int wayPointIndex;

    void Awake()
    {
        enemySight = GetComponent<EnemySight>();
        Debug.Log("Got enemy sighting script");
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
        Debug.Log("got lastPlayerSighting script");
    }


    void Update()
    {
        if (enemySight.personalLastSighting != lastPlayerSighting.resetPosition)
        {
            Chasing01();
            Debug.Log("araf");
        }
        else
        {
            Patrolling();
        }
    }


    void Chasing()
    {
        Vector3 sightingDeltaPos = enemySight.personalLastSighting - transform.position;

        if (sightingDeltaPos.sqrMagnitude > 4f)
        {
            //nav.destination = enemySight.personalLastSighting;
            nav.destination = player.position;
        }

        nav.speed = chaseSpeed;

        if (nav.remainingDistance < nav.stoppingDistance)
        {
            chaseTimer += Time.deltaTime;

            if (chaseTimer > chaseWaitTime)
            {
                lastPlayerSighting.position = lastPlayerSighting.resetPosition;
                enemySight.personalLastSighting = lastPlayerSighting.resetPosition;
                chaseTimer = 0f;
            }
        }
        else
        {
            chaseTimer = 0f;
        }
    }

    void Chasing01()
    {
        nav.destination = player.position;
        
    }


    void Patrolling()
    {
        nav.speed = patrolSpeed;

        if (nav.destination == lastPlayerSighting.resetPosition || nav.remainingDistance < nav.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;

            if (patrolTimer >= patrolWaitTime)
            {
                if (wayPointIndex == patrolWayPoints.Length - 1)
                {
                    wayPointIndex = 0;
                }
                else
                {
                    wayPointIndex++;
                }
                patrolTimer = 0f;
            }
        }

        else
        {
            patrolTimer = 0f;
        }
        nav.destination = patrolWayPoints[wayPointIndex].position;
    }
}
