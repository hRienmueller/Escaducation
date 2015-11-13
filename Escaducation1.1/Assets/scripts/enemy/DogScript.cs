using UnityEngine;
using System.Collections;

public class DogScript : MonoBehaviour {
    public float distance;
    public Vector3 globalLastSighting;

    private GameObject player;
    private NavMeshAgent nav;
    private Animator playerAnim;
    private HashIDs hash;
    private LastPlayerSighting LastPlayerSighting;

    void Awake()
    {
        LastPlayerSighting = GameObject.FindGameObjectWithTag("gameController").GetComponent<LastPlayerSighting>();
        globalLastSighting = LastPlayerSighting.position;    //default position
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        playerAnim = player.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>();
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        nav.destination = player.transform.position;

        int currentAnimatorState = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;
        //Debug.Log("got current state");
        if (currentAnimatorState == hash.idleState)   //if player is walking, not sneaking
        {
            if (distance <= 2.5f)
            {
                LastPlayerSighting.position = player.transform.position;
                Debug.Log("BARK!");
            }
        }
    }
}
