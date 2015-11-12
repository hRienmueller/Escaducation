using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    public int score;
    public string currentExtra;

    private Score scoreScript;
    private InventoryScript inventory;


    void Awake()
    {
        currentExtra = "";
        inventory = GameObject.FindGameObjectWithTag("gameController").GetComponent<InventoryScript>();
        scoreScript = GameObject.FindGameObjectWithTag("gameController").GetComponent<Score>();
    }

    public void OnTriggerEnter(Collider other)  
    {
        Debug.Log("decrease score");
        if (other.gameObject.tag == "Enemy")     //if player gets in seeing or hearing range of an enemy
        {
            score = score - 1;    //decrease score
            scoreScript.UpdateScore01();        // update score
        }

        if (other.gameObject.tag == "extra")  //if player walks through an item
        {
            Debug.Log("extra found");
            currentExtra = other.name;
            Debug.Log(currentExtra);
            score = score + 2;               //increase score
            scoreScript.UpdateScore01();       //update score

           
            other.gameObject.SetActive(false);   //remove exra from the scene
            inventory.OnGUI();
        }
    }

    public void OnTriggerExit(Collider other)    
    {
        Debug.Log("Increase Score");
        if (other.gameObject.tag == "Enemy")      //if player exits seeing or hearing range of an enemy
        {

            score = score + 2;                 //increase score
            scoreScript.UpdateScore01();       // update score
        }
    }
}
