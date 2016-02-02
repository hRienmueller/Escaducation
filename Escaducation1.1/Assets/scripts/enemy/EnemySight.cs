using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    float Seeing;

    void Awake()
    {
        Seeing = 10f;
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();

        personalLastSighting = lastPlayerSighting.resetPosition;  //reset positions, so that the enemies does not start with chasing the player
        previousSighting = lastPlayerSighting.resetPosition;
    }

    void Update()
    {


        if (globalLastSighting != lastPlayerSighting.resetPosition)   //if the dog had barked
        {
        }

        if (lastPlayerSighting.position != previousSighting)   //if lastSightingPosition is not default
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
            anim.SetBool(hash.playerInSightBool, playerInSight);
            //Debug.Log("player in trigger");
            
            Vector3 direction = other.transform.position - transform.position; //Vector between the player and the enemy
            float angle = Vector3.Angle(direction, transform.forward); //angle between the direction vector and the forward vector of the enemy
            if (angle < fieldOfViewAngle*0.5)       //check if player is inside of fieldofview
            {
                RaycastHit hit;
                Debug.Log("in view");
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, Seeing)) //check if enemy is near enough to be seen and nothing is in the way
                {
                    Debug.Log("hit");
                    if (hit.collider.gameObject == player)  //check if the detected gameobject is the player
                    {
                        Debug.Log("player in sight");
                        playerInSight = true;     //player is in sight
                        anim.SetBool(hash.playerInSightBool, playerInSight);
                        personalLastSighting = player.transform.position;   //set lastsightingposition to the players position
                    }
                }
            }

            if (canHear == true) {
                int currentAnimatorState = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;  //check players current state
                float distance = Vector3.Distance(player.transform.position, transform.position);  //distance between enemy and player
                if (currentAnimatorState == hash.walkState)   //if player is walking, not sneaking     
                {
                    if (distance < 5)  //if player is to near
                    {
                        personalLastSighting = player.transform.position;  //go find player
                        playerInSight = true;
                        anim.SetBool(hash.playerInSightBool, playerInSight);
                    }
                    else
                    {
                        playerInSight = false;                             //go on patrol
                        anim.SetBool(hash.playerInSightBool, playerInSight);
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
            //anim.SetBool(hash.playerInSightBool, playerInSight);
        }
    }
}
