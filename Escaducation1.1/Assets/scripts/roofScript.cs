using UnityEngine;
using System.Collections;

public class roofScript : MonoBehaviour
{
    public GameObject Roof;   // the roofObject of the room


    void OnTriggerEnter(Collider other)   // if something enters the trigger area for the room
    {
        if (other.tag == "Player")    // and it is the player
        {
            Roof.SetActive(false);     // disable the roofObject
        }
    }

    void OnTriggerExit(Collider other)   // if something exits the triggerarea of the room
    {
        //Debug.Log("Exited.");
        if (other.tag == "Player")   // and it is the Player
        {
            //Debug.Log("Player Exited");
            Roof.SetActive(true);      // disable the roofObject again
        }
    }
}
