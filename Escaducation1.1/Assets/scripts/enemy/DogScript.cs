﻿using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
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

<<<<<<< HEAD
    public bool IsSausage;                 //check if it is the item is the sausage
    public float dogAttentionZone = 10f;   //for the extra action
    public bool dogExtraDuration;          // how long the extra is active
    public int dogStunTime = 3;            // how long the dog is stunned from the sausage extra
    float dogStunTimer;                    // controls how long the dog is already stunned

    public bool IsBarking;                 // checks if the dog is currently barking
    private Animator anim;
    public float waitSpeed = 0f;           // just fo the animation
    public float walkSpeed = 5f;           // just for te animation

    public float speed;                    // the dog speed
    Text infoText;
=======
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
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409




    void Awake()
    {
<<<<<<< HEAD
       /* infoText = GameObject.FindGameObjectWithTag("infoText").GetComponent<Text>();
        infoText.text = "";*/

        speed = walkSpeed;    // sets the walkingspeed of the animator    
        IsBarking = false;    // dog is not barking

        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();
        anim = GetComponent<Animator>();
        inventory = GameObject.FindGameObjectWithTag("gameController").GetComponent<InventoryScript>();
        dogExtraDuration = false;                      //currently no extra effect is working
=======
        //anim.SetLayerWeight(2, 1f);
        speed = walkSpeed;
        IsBarking = false;
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();

        anim = GetComponent<Animator>();

        inventory = GameObject.FindGameObjectWithTag("gameController").GetComponent<InventoryScript>();
        dogExtraDuration = false;
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
        Barking = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerscore = player.GetComponent<PlayerScore>();
        LastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
        globalLastSighting = LastPlayerSighting.position;                //default position
        nav = GetComponent<NavMeshAgent>();
        playerAnim = player.GetComponent<Animator>();
<<<<<<< HEAD
        SniffDistance = 2.5f;   // Distance, in which the dog must get to bark
        IsSausage = false;      // is a sausage in the inventory? 

        anim.SetLayerWeight(1, 1);
        anim.SetLayerWeight(2, 1); 
=======
        SniffDistance = 2.5f;   //Distance, in which the dog must get to bark
        IsSausage = false;        
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
    }

    void Update()
    {
<<<<<<< HEAD
        //Debug.Log("speed: " + speed);
        anim.SetFloat(hash.DogSpeed, nav.speed);     // set the speed of the navmeshAgent
        distance = Vector3.Distance(player.transform.position, transform.position);   // calculating the distance between the player and the dog
        nav.destination = player.transform.position;       // the target for the dog to get to is always the player -> dog follows player
=======
        Debug.Log("speed : " + speed);
        anim.SetFloat(hash.DogSpeed, speed);
        distance = Vector3.Distance(player.transform.position, transform.position);   //calculating the distance between the player and the dog
        nav.destination = player.transform.position;    // the target for the dog to get to is always the player -> dog follows player
        //Debug.Log(nav.destination);
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409

        int currentAnimatorState = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;  //check state, the player is in
        if (currentAnimatorState == hash.idleState)   //if player is standing, not sneaking or walking
        {
            if (distance <= SniffDistance)         //if the dog is near enough
            {
<<<<<<< HEAD
                Wait();    // call waitfunction
=======
                
                Wait();
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
            }

            else                    //if the dog is not near enough (anymore)...
            {
<<<<<<< HEAD
                Barking.Stop();                           //...stop barking
                anim.SetBool(hash.barkingBool, false);    // sets the IsBarkingBool in the animatorcontroller
                //Debug.Log("Stopped playing");
                speed = walkSpeed;                        // sets  the speed variable in the animator
                anim.SetFloat(hash.DogSpeed, speed);
            }

            if (Input.GetButtonDown("Action"))            // if the action key is pressed...
            {
                if(distance <= dogAttentionZone)          // ...and the player is near enough...
                {
                    dogExtraDuration = true;              // ... activate extra effect
                }
            }

            if(dogExtraDuration == true)                  //if extra effect is activated...
            {
                CheckDogExtra();                          // ... check which extra is currently in the inventory
            }

            if(IsSausage == true)                         // if the extra is the sausage
=======
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
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
            {
                dogStunTimer += Time.deltaTime;     //increase timer

                if (dogStunTimer <= dogStunTime)   //if timer equals or is higher as the generalWaittime ->this does not work, even without the .setactive before.
                {
                    nav.Stop();                     //stop navMeshAgent
<<<<<<< HEAD
                   // infoText.text = "Dog stunned...";
                    speed = waitSpeed;              // set speed to 0, to have the idle animation playing.
                    anim.SetFloat(hash.DogSpeed, speed);
                    //Debug.Log("DOGstunned");
=======
                    Debug.Log("DOGstunned");
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
                    dogExtraDuration = false;        //set extra duration to false, 
                }
                else
                {
                    nav.Resume();                    //call navmeshagent back to live, reset every boolean
<<<<<<< HEAD
                    infoText.text = "";
                    speed = walkSpeed;                 // set speed to walkingspeed. for animation
                    anim.SetFloat(hash.DogSpeed, speed);
                    dogStunTimer = 0f;                  // reset the timer
                    IsSausage = false;                  //sausage is not longer in inventory
                    dogExtraDuration = false;            //extra is no longer active
=======
                    dogStunTimer = 0f;                  // reset the timer
                    IsSausage = false;
                    dogExtraDuration = false;
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
                }
            }
        }
    }

<<<<<<< HEAD
    void CheckDogExtra()            // this function checks which extra is currently in the inventory
    {
        if (inventory.InventoryContains("Sausage"))     // if the inventory contains a sausage
        {
            Debug.Log("Inventory contains Sausage");
            IsSausage = true;                           //set isSausage to true
        }
    }

=======
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
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409

    void Bark()
    {
        
        Barking.Play();   //...bark.
    }

    void Wait()
    {
<<<<<<< HEAD
        speed = waitSpeed;        // sets the speed in the animator
        anim.SetFloat(hash.DogSpeed, speed);
        barkTimer += Time.deltaTime;   // increase barktimer
=======
        speed = waitSpeed;
        barkTimer += Time.deltaTime;
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
        //Debug.Log(barkTimer);

        if (barkTimer >= barkWaitTime)  //and has waited long enough
        {
            IsBarking = true;

          

            if (Barking.isPlaying == false) //and is not already barking
            {
<<<<<<< HEAD
                anim.SetBool(hash.barkingBool, true);     //sets the isBarking boolean variable in the animator
                Bark();                                  // play sound 
=======
                anim.SetBool(hash.barkingBool, true);
                Bark();
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
                
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
