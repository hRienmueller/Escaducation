using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;

    private NavMeshAgent nav;
    private SphereCollider col;
    private Animator anim;         //enemy animator reference

    private GameObject player;
    private Animator playerAnim;   //player animator reference
    private HashIDs hash;

    private Vector3 previousSighting; // has player changed his position?
    private LastPlayerSighting lastPlayerSighting;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();

        personalLastSighting = lastPlayerSighting.resetPosition;
        previousSighting = lastPlayerSighting.resetPosition;
    }

    void Update()
    {
        if (lastPlayerSighting.position != previousSighting)
        {
            personalLastSighting = lastPlayerSighting.position;
        }
        previousSighting = lastPlayerSighting.position;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInSight = false;

            Vector3 direction = other.transform.position - transform.position; //Vector between the player and the enemy
            float angle = Vector3.Angle(direction, transform.forward); //angle between the direction vector and the forward vector of the enemy
            Debug.Log(angle);
            if (angle < fieldOfViewAngle*0.5)       //check if player is inside of fieldofview
            {
                RaycastHit hit;
                Debug.Log("in view");
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius)) //check if enemy is near enough to be seen and nothing is in the way
                {
                    Debug.Log("hit");
                    if (hit.collider.gameObject == player)
                    {
                        Debug.Log("player in sight");
                        playerInSight = true;
                        personalLastSighting = player.transform.position;
                    }
                }
            }

            int playerLayerZeroStateHash = playerAnim.GetCurrentAnimatorStateInfo(0).nameHash;
            if (playerLayerZeroStateHash == hash.walkState)
            {
                if (CalculatePathLenght(player.transform.position)<= col.radius)
                {
                    personalLastSighting = player.transform.position;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
        }
    }

    float CalculatePathLenght(Vector3 targetPosition)  //to make sure the enemy cannot hear through walls
    {
        NavMeshPath path = new NavMeshPath();   //calculate the length of the path the sound must travel from the player to the enemy
        if (nav.enabled)
        {
            nav.CalculatePath(targetPosition, path);
        }

        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;
        for (int i = 0; i< path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }
        float pathLength = 0f;   //cannot be incremented if it is not initialized
        for (int i =0; i<allWayPoints.Length-1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }
        return pathLength;
    }
}
