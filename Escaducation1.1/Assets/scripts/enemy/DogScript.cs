using UnityEngine;
using System.Collections;

public class DogScript : MonoBehaviour {
    public float distance;   //distance between the player and the dog
    public Vector3 globalLastSighting;   //reference to the place, where the player was seen the last time. Every enemy knows
    public float SniffDistance;   //alarm distance of the dog
    public float barkWaitTime;    //Time the dog waits till he barks

    private GameObject player;   //the player gameobject
    private NavMeshAgent nav;    //the navMeshAgent component of the dog
    private Animator playerAnim;  //the player Animator
    private HashIDs hash;   //reference to the HashIDs script
    private LastPlayerSighting LastPlayerSighting;   //reference to the lastPlayerSightingScript
    private float barkTimer;  //Just a timer 


    void Awake()
    {
        LastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
        globalLastSighting = LastPlayerSighting.position;                //default position
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        playerAnim = player.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();
        SniffDistance = 2.5f;   //Distance, in which the dog must get to bark
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);   //calculating the distance between the player and the dog
        nav.destination = player.transform.position;    // the target for the dog to get to is always the player -> dog follows player

        int currentAnimatorState = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;  //check state, the player is in
        //Debug.Log("got current state");
        if (currentAnimatorState == hash.idleState)   //if player is standing, not sneaking or walking
        {
            if (distance <= SniffDistance)         //if the dog is near enough
            {
                barkTimer += Time.deltaTime;
                //Debug.Log(barkTimer);

                if (barkTimer >= barkWaitTime)
                {
                    LastPlayerSighting.position = player.transform.position;  //alarm the other enemies
                    //Debug.Log(LastPlayerSighting.position);
                    Debug.Log("BARK!");
                    barkTimer = 0f;
                }
            }
        }
    }
}
