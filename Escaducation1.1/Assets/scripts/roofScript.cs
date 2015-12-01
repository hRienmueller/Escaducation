using UnityEngine;
using System.Collections;

public class roofScript : MonoBehaviour
{
    public GameObject Roof;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Roof.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited.");
        if (other.tag == "Player")
        {
            Debug.Log("Player Exited");
            Roof.SetActive(true);
        }
    }
}
