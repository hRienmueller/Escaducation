using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour
{
    public float deadZone = 5f;

    private Transform player;
    private EnemySight enemySight;
    private NavMeshAgent nav;
    private Animator anim;
    private HashIDs hash;
    private AnimatorSetup animSetup;
    private enemyAI EnemyAI;

    void Awake()
    {
        //referencing scripts
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemySight = GetComponent<EnemySight>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();
        EnemyAI = GetComponent<enemyAI>();

        nav.updateRotation = false;                //make sure the rotation is controlled by mecanim
        animSetup = new AnimatorSetup(anim, hash); //creating an instance of the AnimatorSetu class and calling it´s constructor
        deadZone += Mathf.Deg2Rad;                 //convert the angle for the deadzone from degrees to radiants
    }


    void Update()
    {
        NavAnimSetup();
    }


    void OnAnimatorMove()
    {
        
        nav.velocity = anim.deltaPosition / Time.deltaTime;  // Set the navMeshs velocity to the change in position since the last frame, by the time it took for the last frame
        transform.rotation = anim.rootRotation;  // gameobject´s rotation is driven by the animations rotation
    }


    void NavAnimSetup()
    {
        float speed;    // the enemies walking speed
        float angle;    //the enemies angle towards the player

        if (enemySight.playerInSight)  //if player is in sight
        {
            speed = EnemyAI.chaseSpeed;   //start running
            anim.SetFloat(hash.enemySpeed, speed);
            angle = FindAngle(transform.forward, player.position - transform.position, transform.up); //look at player
        }
        else
        {
            speed = Vector3.Project(nav.desiredVelocity, transform.forward).magnitude;  //set speed based on te velocity of the navmesh
            angle = FindAngle(transform.forward, nav.desiredVelocity, transform.up);   //set angle based on the velocity of the navmesh

            if (Mathf.Abs(angle) < deadZone)  //if angle is in the dead zone
            {
                transform.LookAt(transform.position + nav.desiredVelocity); //set direction to be along the desired direction...
                angle = 0f;                                           //...and the angle to zero
            }
        }
        animSetup.Setup(speed, angle);   //call elperfunction with the given parameters
    }

    float FindAngle(Vector3 fromVector, Vector3 toVector, Vector3 upVector) //calculate angle
    {
        if(toVector == Vector3.zero)  //if the vector the angle is being calculated to is zero
        {
            return 0f;   //the angle between them is zero
        }

        float angle = Vector3.Angle(fromVector, toVector);  //this stores the angle between facing of the enemy and the direction of his travelling
        Vector3 normal = Vector3.Cross(fromVector, toVector); //Find the cross product of the two vectors
        angle *= Mathf.Sign(Vector3.Dot(normal, upVector));   //The dot Product
        angle *= Mathf.Deg2Rad;   //convert the angle from degrees to radians

        return angle;  //return the angle
    }
}
