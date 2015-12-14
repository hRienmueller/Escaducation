using UnityEngine;
using System.Collections;

public class DogScript : MonoBehaviour {
    public float distance;   //distance between the player and the dog
    public Vector3 globalLastSighting;   //reference to the place, where the player was seen the last time. Every enemy knows
    public float SniffDistance;   //alarm distance of the dog
    public float barkWaitTime;    //Time the dog waits till he barks

    public GameObject player;   //the player gameobject
    private NavMeshAgent nav;    //the navMeshAgent component of the dog
    private Animator playerAnim;    //the player Animator
    private HashIDs hash;        //reference to the HashIDs script
    private LastPlayerSighting LastPlayerSighting;   //reference to the lastPlayerSightingScript
    private float barkTimer;          //Just a timer 
    private PlayerScore playerscore;  //to check the item the player is carrying

    public AudioSource Barking;


    void Awake()
    {
        Barking = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerscore = player.GetComponent<PlayerScore>();
        LastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
        globalLastSighting = LastPlayerSighting.position;                //default position
        nav = GetComponent<NavMeshAgent>();
        playerAnim = player.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();
        SniffDistance = 1.8f;   //Distance, in which the dog must get to bark
        
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

                    if (barkTimer >= barkWaitTime )  //and has waited long enough
                    {
                        if(Barking.isPlaying == false) //and is not already barking
                        {
                            Barking.Play();   //...bark.
                        }
                     LastPlayerSighting.position = player.transform.position;  //alarm the other enemies
                                                                                //Debug.Log(LastPlayerSighting.position);
                     //Debug.Log("BARK!");
                     barkTimer = 0f;  //reset bark timer
                    }
                
            }
            else                    //if the dog is not near enough (anymore)...
            {
                Barking.Stop();     //...stop barking
                Debug.Log("Stopped playing");
            }
        }
    }
}
