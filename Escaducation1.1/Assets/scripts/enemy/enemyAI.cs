using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour {

    public float Speed = 3;
    public float giveUpDistance;
    public float chaseDistance = 9999f;

    public Transform target;
    public Transform WayPoint01;
    public Transform WayPoint02;
    //public Transform WayPoint03;
   // public Transform WayPoint04;
    public Transform Startpoint;
    public Transform enemy;

    private NavMeshAgent nav;
    private bool WP01Reached;  // is waypoint 01 reached?
    private bool WP02Reached;  // is waypoint 02 reached?

    private bool IsChasing;

    void Awake() {
        nav = GetComponent<NavMeshAgent>();
        WP01Reached = false;
        WP02Reached = true;
        nav.destination = WayPoint01.position;
        IsChasing = false;
    }

   

    void Update()
    {
        chaseDistance = Vector3.Distance(target.position, enemy.position);

        if (chaseDistance > giveUpDistance)
        {
            if(IsChasing == true) { 
                nav.destination = WayPoint01.position;
                WP01Reached = false;
                WP02Reached = true;

                IsChasing = false;
                Debug.Log("RESET");
            }

            Patrol();
            //Debug.Log(transform.position + "/" + WayPoint01.position);
           // Debug.Log("patrolling");
        }
        else {
            //Debug.Log("chasing");

            IsChasing = true;

            Chase();
            if(chaseDistance > giveUpDistance)  {
               
            }
        }
    }

    void Chase() {
        nav.destination = target.position;
    }

    void Patrol() {
        if (WP02Reached == true && enemy.position.x == WayPoint01.position.x && enemy.position.z == WayPoint01.position.z) {
          nav.destination = WayPoint02.position;
            WP01Reached = true;
            WP02Reached = false;  
            Debug.Log("changing to destination wp02... ");
        }

        else if (WP01Reached == true && enemy.position.x == WayPoint02.position.x && enemy.position.z == WayPoint02.position.z) {
            nav.destination = WayPoint01.position;
            WP01Reached = false;
            WP02Reached = true;
            Debug.Log("changing to destination wp01...");
        }

       
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.transform.position = Startpoint.position;
        }
    }
 
}
