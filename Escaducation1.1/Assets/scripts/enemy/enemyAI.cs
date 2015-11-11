using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;    //speed of enemy in the patrolling state
    public float chaseSpeed = 5f;     //speed of the enemy in the chasing state
    public float chaseWaitTime = 2f;   //time the enemy will wait at the last sighting position of the player
    public float patrolWaitTime = 1f;   //time the enemy will wait on each wayPoint
    public Transform[] patrolWayPoints;   //array to store the waypoints
    public float killDistance = 0.5f;     //Distance in which the player is considered as catched
    public Transform startPoint;

    private EnemySight enemySight;
    private NavMeshAgent nav;
    public Transform player;
    private LastPlayerSighting lastPlayerSighting;
    private float chaseTimer;      //timer to check the time the enemy is already waiting at the players last sighting position
    private float patrolTimer;     //timer to check the time the enemy is already waiting at the current waypoint
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
        if (enemySight.personalLastSighting != lastPlayerSighting.resetPosition)  //when the players last sighting pos is not default
        {
            Chasing();

        }
        else
        {
            Patrolling();
        }
    }


    void Chasing()
    {
        float distance  = Vector3.Distance(player.position, transform.position);  //distance between enemy and player
        if(enemySight.playerInSight == false)  //if player is not in sight
        {
           //set destination to last sighting point
            nav.destination = enemySight.personalLastSighting;
        }
        else if(enemySight.playerInSight == true) //if player is near
        {
            nav.destination = player.transform.position;     // set destination to players position
            if(distance < killDistance)                      // if player is in killDistance
            {
                //Debug.Log("Gotcha!");
                player.position = startPoint.position;
            }
        }

        nav.speed = chaseSpeed;

        if (nav.remainingDistance < nav.stoppingDistance) //if enemy has reached the last player sighting position
        {
            chaseTimer += Time.deltaTime;   // start the timer

            if (chaseTimer > chaseWaitTime)  //if enemy has waited long enough
            {
                lastPlayerSighting.position = lastPlayerSighting.resetPosition;   //reset positions 
                enemySight.personalLastSighting = lastPlayerSighting.resetPosition;
                chaseTimer = 0f;  //reset timer
            }
        }
        else
        {
            chaseTimer = 0f;
        }
    }


    void Patrolling()
    {
        nav.speed = patrolSpeed;    //set speed

        if (nav.destination == lastPlayerSighting.resetPosition || nav.remainingDistance < nav.stoppingDistance)  //if current waypoint is reached
        {
            patrolTimer += Time.deltaTime;    //start timer

            if (patrolTimer >= patrolWaitTime)   // if enemy has waited long enough
            {
                if (wayPointIndex == patrolWayPoints.Length - 1)  // if end of waypoint array is finished
                {
                    wayPointIndex = 0;    //reset waypointindex to start anew
                }
                else
                {
                    wayPointIndex++;  //increase waypoint index
                }
                patrolTimer = 0f;  //reset timer
            }
        }

        else
        {
            patrolTimer = 0f; //reset timer
        }
        nav.destination = patrolWayPoints[wayPointIndex].position;  // set destination to the Waypoint that is indicated by the current index
    }
}

