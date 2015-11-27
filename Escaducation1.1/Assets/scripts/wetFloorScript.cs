using UnityEngine;
using System.Collections;

public class wetFloorScript : MonoBehaviour
{
    public float wetFloorSpeed;
    public bool PlayerEntered = false;
    public float DragFloat;

    private NavMeshAgent nav;
    private GameObject player;
    private Rigidbody rigidbody;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = player.GetComponent<NavMeshAgent>();
        rigidbody = player.GetComponent<Rigidbody>();
        rigidbody.drag = 0;
         
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerEntered = true;
            rigidbody.drag = DragFloat;
            Debug.Log("Player entered...");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            rigidbody.drag = 0;
            PlayerEntered = false;
            Debug.Log("Player exited...");
        }
    }
}
