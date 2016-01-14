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
    private InventoryScript inventory;

    public AudioSource Barking;

    public bool IsSausage;   //check if it is the item is the sausage
    public float dogAttentionZone = 10f;
    public bool dogExtraDuration;
    public int dogStunTime = 3;
    float dogStunTimer;

    public bool IsBarking;
    private Animator anim;
    public float waitSpeed = 0f;
    public float walkSpeed = 5f;

    public float speed;




    void Awake()
    {
        //anim.SetLayerWeight(2, 1f);
        speed = walkSpeed;
        IsBarking = false;
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();

        anim = GetComponent<Animator>();

        inventory = GameObject.FindGameObjectWithTag("gameController").GetComponent<InventoryScript>();
        dogExtraDuration = false;
        Barking = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerscore = player.GetComponent<PlayerScore>();
        LastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
        globalLastSighting = LastPlayerSighting.position;                //default position
        nav = GetComponent<NavMeshAgent>();
        playerAnim = player.GetComponent<Animator>();
        SniffDistance = 2.5f;   //Distance, in which the dog must get to bark
        IsSausage = false;        
    }

    void Update()
    {
        Debug.Log("speed : " + speed);
        anim.SetFloat(hash.DogSpeed, speed);
        distance = Vector3.Distance(player.transform.position, transform.position);   //calculating the distance between the player and the dog
        nav.destination = player.transform.position;    // the target for the dog to get to is always the player -> dog follows player
        //Debug.Log(nav.destination);

        int currentAnimatorState = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;  //check state, the player is in
        if (currentAnimatorState == hash.idleState)   //if player is standing, not sneaking or walking
        {
            if (distance <= SniffDistance)         //if the dog is near enough
            {
                
                Wait();
            }

            else                    //if the dog is not near enough (anymore)...
            {
                Barking.Stop();     //...stop barking
                anim.SetBool(hash.barkingBool, false);
                Debug.Log("Stopped playing");
                speed = walkSpeed;
            }

            if (Input.GetButtonDown("Action"))
            {
                if(distance <= dogAttentionZone)
                {
                    dogExtraDuration = true;
                }
            }

            if(dogExtraDuration == true)
            {
                CheckDogExtra();
            }

            if(IsSausage == true)
            {
                dogStunTimer += Time.deltaTime;     //increase timer

                if (dogStunTimer <= dogStunTime)   //if timer equals or is higher as the generalWaittime ->this does not work, even without the .setactive before.
                {
                    nav.Stop();                     //stop navMeshAgent
                    Debug.Log("DOGstunned");
                    dogExtraDuration = false;        //set extra duration to false, 
                }
                else
                {
                    nav.Resume();                    //call navmeshagent back to live, reset every boolean
                    dogStunTimer = 0f;                  // reset the timer
                    IsSausage = false;
                    dogExtraDuration = false;
                }
            }
        }
    }

    void CheckDogExtra()
    {
        if (inventory.InventoryContains("Sausage"))
        {
            Debug.Log("Inventory contains Sausage");
            IsSausage = true;
        }
    }

    /*void followPlayer()
    {
        nav.speed = walkSpeed;
    }*/

    void Bark()
    {
        
        Barking.Play();   //...bark.
    }

    void Wait()
    {
        speed = waitSpeed;
        barkTimer += Time.deltaTime;
        //Debug.Log(barkTimer);

        if (barkTimer >= barkWaitTime)  //and has waited long enough
        {
            IsBarking = true;

          

            if (Barking.isPlaying == false) //and is not already barking
            {
                anim.SetBool(hash.barkingBool, true);
                Bark();
                
            }

            else
            {
                IsBarking = false;
            }
            LastPlayerSighting.position = player.transform.position;  //alarm the other enemies
                                                                      //Debug.Log(LastPlayerSighting.position);
                                                                      //Debug.Log("BARK!");
            barkTimer = 0f;  //reset bark timer
        }
    }
}
