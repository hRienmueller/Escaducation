using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;   // enemies field of view in degree
    public bool playerInSight;              //check if the player is in sight
    public Vector3 personalLastSighting;     // position of the last sighting of the player
    public Vector3 globalLastSighting;      //position, from which the dog last barked at the player
    public bool canHear;

    private NavMeshAgent nav;
    private SphereCollider col;
    private Animator anim;         //enemy animator reference

    private GameObject player;     //the player
    private Animator playerAnim;   //player animator reference
    private HashIDs hash;          // reference to the HashIDs script

    private Vector3 previousSighting; // has player changed his position?
    private LastPlayerSighting lastPlayerSighting; //reference to the LastPlayerSighting script

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();

        personalLastSighting = lastPlayerSighting.resetPosition;  //reset positions, so that the enems does not start with chasing the player
        previousSighting = lastPlayerSighting.resetPosition;
    }

    void Update()
    {
        if (globalLastSighting != lastPlayerSighting.resetPosition)   //if the dog had barked
        {
            nav.destination = globalLastSighting;   //go checking the position the noise came from
        }

        if (lastPlayerSighting.position != previousSighting)   //if lastSightingPosition is ot default
        {
            personalLastSighting = lastPlayerSighting.position;  //make it to new position
        }
        previousSighting = lastPlayerSighting.position;    //make it to previous position to have space for a new position
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)   //if player enters the trigger area
        {
            playerInSight = false;       // player is not automatically seen

            Vector3 direction = other.transform.position - transform.position; //Vector between the player and the enemy
            float angle = Vector3.Angle(direction, transform.forward); //angle between the direction vector and the forward vector of the enemy
            //Debug.Log(angle);
            if (angle < fieldOfViewAngle*0.5)       //check if player is inside of fieldofview
            {
                RaycastHit hit;
                //Debug.Log("in view");
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius)) //check if enemy is near enough to be seen and nothing is in the way
                {
                    //Debug.Log("hit");
                    if (hit.collider.gameObject == player)  //check if the detected gameobject is the player
                    {
                        //Debug.Log("player in sight");
                        playerInSight = true;     //player is in sight
                        personalLastSighting = player.transform.position;   //set lastsightingposition to th eplayers position
                    }
                }
            }

            if (canHear == true) {
                int currentAnimatorState = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;
                //Debug.Log("got current state");
                if (currentAnimatorState == hash.walkState)   //if player is walking, not sneaking
                {
                    //Debug.Log("WalkingState detected");
                    if (CalculatePathLenght(player.transform.position) <= col.radius)  //if player is not behind a wall
                    {
                        personalLastSighting = player.transform.position;  //go find player without setting the playerInSight boolean to true
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)   //if player leaves the trigger area
        {
            playerInSight = false;    // the enemy cannot see him anymore
        }
    }

    float CalculatePathLenght(Vector3 targetPosition)  //to make sure the enemy cannot hear through walls
    {
        NavMeshPath path = new NavMeshPath();   //calculate the length of the path the sound must travel from the player to the enemy
        if (nav.enabled)        //if the navMesh is enabled
        {
            nav.CalculatePath(targetPosition, path);   //calculate the path between the enemy and the player
        }

        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];   //all edges of the way, plus the position of the enmy and the player
        allWayPoints[0] = transform.position;                     //first edgepoint is the enemy himself
        allWayPoints[allWayPoints.Length - 1] = targetPosition;   //last edgepoint is the player
        for (int i = 0; i< path.corners.Length; i++)    //iterate through the array
        {
            allWayPoints[i + 1] = path.corners[i];     //fill the array with the edgepoints
        }
        float pathLength = 0f;   //cannot be incremented if it is not initialized
        for (int i =0; i<allWayPoints.Length-1; i++)    //iterate through the array
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);   //calculate the pathlength between the edgepoints
        }
        return pathLength;     //return the lenght of the path as float
    }
}
