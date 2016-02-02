using UnityEngine;
using System.Collections;

public class wetFloorScript : MonoBehaviour
{
    public bool PlayerEntered = false;   //Just for Debug reasons
    public float DragFloat;              //defines how much the drag value of the rigidbody is increased

    private NavMeshAgent nav;            // reference to the navMeshAgent of the player
    private GameObject player;           // reference to the playerGameObject
    new private Rigidbody rigidbody;         // reference to the Players rigidbody

    void Awake()
    {
        // setting references 
        player = GameObject.FindGameObjectWithTag("Player");
        nav = player.GetComponent<NavMeshAgent>();
        rigidbody = player.GetComponent<Rigidbody>();
        rigidbody.drag = 0;
         
    }


    void OnTriggerEnter(Collider other)    //if something enters the triggerArea
    {
        if (other.tag == "Player")         //and it is the player
        {
            PlayerEntered = true;          //set PlayerEntered to true
            rigidbody.drag = DragFloat;    //set the drag component of the rigidbody to the defined drag value
            //Debug.Log("Player entered...");
        }
    }

    void OnTriggerExit(Collider other)     //if something exits the triggerArea
    {
        if (other.tag == "Player")         //and it is the player
        {
            rigidbody.drag = 0;            //set the drag component of the rigidbody to zero
            PlayerEntered = false;         //set PlayerEntered to false
            //Debug.Log("Player exited...");
        }
    }
}
