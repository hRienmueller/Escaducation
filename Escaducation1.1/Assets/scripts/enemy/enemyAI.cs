﻿using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
using System.Collections;

public class enemyAI : MonoBehaviour
{
    public float stunnedSpeed = 0f;   //speed of enemy in stunned state
    public float patrolSpeed = 2f;    //speed of enemy in the patrolling state
    public float chaseSpeed = 9f;     //speed of the enemy in the chasing state
    public float chaseWaitTime = 2f;   //time the enemy will wait at the last sighting position of the player
    public float patrolWaitTime = 1f;   //time the enemy will wait on each wayPoint
    public float attentionZone = 10f;    
    public Transform[] patrolWayPoints;   //array to store the waypoints
<<<<<<< HEAD
    public float killDistance = 4f;     //Distance in which the player is considered as catched
=======
    public float killDistance = 0.5f;     //Distance in which the player is considered as catched
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
    public Transform startPoint;
    public float generalWaitTime = 3f;       //Timer for extra stunned time
    public bool ExtraDurationOn;            //checks if duration of an extra is true at the current time

    private InventoryScript inventory;
    private EnemySight enemySight;
    private NavMeshAgent nav;
    public Transform player;
    public GameObject enemy;
    public int IntScore;
    public bool IsSponge;
    public bool IsChalk;

    public GameObject Attention;  //the attentionMark above the enemies head

    private PlayerScore playerScore;
    private LastPlayerSighting lastPlayerSighting;
    private onButtonClick changeScenes;
    private float chaseTimer;      //timer to check the time the enemy is already waiting at the players last sighting position
    private float patrolTimer;     //timer to check the time the enemy is already waiting at the current waypoint
    private int wayPointIndex;     //to identify a certain waypoint in the waypointsArray
    public float stunTimer;      //timer to check the time the enemy is stunned

    public AudioSource AlarmSound; //the soundclip
    public bool SoundPlay;         //to make sure the sound plays only once

<<<<<<< HEAD
    Animator anim;
    private HashIDs hash;
    Text infoText;


=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409


    void Awake()
    {
<<<<<<< HEAD
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();
=======
      
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409

        SoundPlay = false;
        Attention.SetActive(false);
        ExtraDurationOn = false;
        changeScenes = GameObject.FindGameObjectWithTag("gameController").GetComponent<onButtonClick>();
        inventory = GameObject.FindGameObjectWithTag("gameController").GetComponent<InventoryScript>();
        enemySight = GetComponent<EnemySight>();
        //Debug.Log("Got enemy sighting script");
        nav = GetComponent<NavMeshAgent>();
        // Debug.Log("got navmeshagnet"+ transform.name);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        IntScore = playerScore.score;
        lastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
        //Debug.Log("got lastPlayerSighting script");
        //Debug.Log(patrolWayPoints[0]);
        IsSponge = false;
        IsChalk = false;
    }
    void Start()
    {
<<<<<<< HEAD
       /* infoText = GameObject.FindGameObjectWithTag("infoText").GetComponent<Text>();
        infoText.text = "";*/
        nav.destination = patrolWayPoints[0].position;
       // anim.SetFloat(hash.speedFloat, patrolSpeed);
=======
        nav.destination = patrolWayPoints[0].position;
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
    }


    void Update()
    {

        //Debug.Log("destination:" + nav.destination + ", current position: " + transform.position);

        float distance = Vector3.Distance(player.position, transform.position);  //distance between enemy and player
<<<<<<< HEAD
        //Debug.Log("distance: " + distance);
=======

>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
        if (Input.GetButtonDown("Action"))  //if you press the button which uses an item
        {
            if(distance < attentionZone) //if player uses item near enough to enemy
            {
                ExtraDurationOn = true;  //activate extra
            }
        }

        if(IsSponge == true)
        {
            //Debug.Log("stunned");
            stunTimer += Time.deltaTime;     //increase timer
<<<<<<< HEAD
            infoText.text = "Teacher stunned...";
=======

>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
            if (stunTimer <= generalWaitTime)   //if timer equals or is higher as the generalWaittime ->this does not work, even without the .setactive before.
            {
                nav.Stop();                     //stop navMeshAgent
                Debug.Log("stunned");
                ExtraDurationOn = false;        //set extra duration to false, 
            }
            else
            {
                nav.Resume();                    //call navmeshagent back to live, reset every boolean
<<<<<<< HEAD
                infoText.text = "";
=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
                Chasing();                       //resume to chase the player
                stunTimer = 0f;                  // reset the timer
                IsSponge = false;
                ExtraDurationOn = false;
            }
        }

        if (IsChalk == true)
        {
            stunTimer += Time.deltaTime;
            nav.destination = startPoint.position;
            Debug.Log("destination Startpoint");
<<<<<<< HEAD
            infoText.text = "Teacher distracted...";
=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409

            if (stunTimer >= generalWaitTime)
            {
                IsChalk = false;
                stunTimer = 0;
                ExtraDurationOn = false;
<<<<<<< HEAD
                infoText.text = "";
=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
                Chasing();
            }
        }

        if (ExtraDurationOn == true )   //if extra ist activated
        {
            CheckExtra();   //check which one it is and trigger its special abilities
        }

        if (enemySight.personalLastSighting != lastPlayerSighting.resetPosition && ExtraDurationOn == false)  //when the players last sighting pos is not default
        {
            if(AlarmSound.isPlaying == false && SoundPlay == false)  // if the alarmsound is not already playing
            {
                AlarmSound.Play(); //...play the alarm sound
                SoundPlay = true;
            }

            //Debug.Log("AttentionSoundPlayed");
            Chasing();   //hunt the player
        }

        else             
        {
            if (ExtraDurationOn == false)
            {
                Patrolling();      //patrol between certain points
            }
        }
    }


    void Chasing()
    {
        Debug.Log("Chasing");
        Attention.SetActive(true); //let the attention mark appear
       
        //Debug.Log("chasing");
        float distance  = Vector3.Distance(player.position, transform.position);  //distance between enemy and player
        if(enemySight.playerInSight == false)  //if player is not in sight
        {
            nav.SetDestination(enemySight.personalLastSighting);
        }
        else if(enemySight.playerInSight == true) //if player is near
        {
            // set destination to players position
            nav.SetDestination(player.transform.position);
            if(distance < killDistance)                      // if player is in killDistance
            {
                //Debug.Log("player as good as dead");
                PlayerPrefs.SetInt("ScoreInt", IntScore);  //this does nt work, but it should store the score value so that it is not deleted by changing the scene

                changeScenes.changeScenes("StartScreen");  //change the scene to startscene
                //Debug.Log("Scene changed");
            }
        }

        nav.speed = chaseSpeed;   //set speed to chaseSpeed
<<<<<<< HEAD
       // anim.SetFloat(hash.speedFloat, chaseSpeed);
=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409

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
            chaseTimer = 0f;    //reset timer
        }
    }


    void Patrolling()
    {
        SoundPlay = false;
        Attention.SetActive(false); //let the attention mark above the head disappear
        nav.speed = patrolSpeed;    //set speed
<<<<<<< HEAD
        //anim.SetFloat(hash.speedFloat, patrolSpeed);
        
=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409

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
                nav.SetDestination(patrolWayPoints[wayPointIndex].position); //set new destination
            }
        }

        else
        {
            patrolTimer = 0f; //reset timer
        }
        //Debug.Log("position patrolpoint: " + patrolWayPoints[wayPointIndex].position);
       // Debug.Log("set destination: =" + nav.SetDestination(patrolWayPoints[wayPointIndex].position));
       // Debug.Log("navmeshAgent destination: " + nav.destination);
        
    }

    void CheckExtra()
    {
        if (inventory.InventoryContains("sponge")) //if inventory at the current time contains a sponge
        {
            IsSponge = true;
        }
        if (inventory.InventoryContains("Paperthingy")) //if inventory at the current time contains the paperplane
        {
            IsChalk = true;
        }
    }
}

