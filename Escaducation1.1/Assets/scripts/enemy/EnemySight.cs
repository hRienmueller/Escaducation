using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

    public float fieldOfViewAngle = 120f;
    public bool playerInSight;
    //public Vector3 personalLastSighting;
    public GameObject player;

    private NavMeshAgent nav;
    private SphereCollider col;
    
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        Debug.Log("collider found!");
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("player inside");
            playerInSight = false;
            Vector3 direction = other.transform.position -transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < fieldOfViewAngle * 0.5)
            {
                RaycastHit hit;
                Debug.Log("Raycast caaaasteeeed");
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if (hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        Debug.Log("playerInSight = true");
                    }
                }
            }
        }
    }
}
