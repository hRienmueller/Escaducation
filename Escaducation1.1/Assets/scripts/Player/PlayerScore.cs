using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    public int score;
    public string currentExtra;
    public float countMaxTime;

    private Score scoreScript;
    private InventoryScript inventory;
    private float countTimer;


    void Awake()
    {
        currentExtra = "   ";
        inventory = GameObject.FindGameObjectWithTag("gameController").GetComponent<InventoryScript>();
        scoreScript = GameObject.FindGameObjectWithTag("gameController").GetComponent<Score>();
    }

    public void Update()
    {
        countTimer += Time.deltaTime;
        if (countTimer >= countMaxTime)
        {
            score = score + 20;
            countTimer = 0f;
            PlayerPrefs.SetInt("IntScore", score);
        }
    }

    public void OnTriggerEnter(Collider other)  
    {
        //Debug.Log("decrease score");
        if (other.gameObject.tag == "Enemy")     //if player gets in seeing or hearing range of an enemy
        {
            score = score - 1;    //decrease score
            scoreScript.UpdateScore01();        // update score
            PlayerPrefs.SetInt("IntScore", score);
        }

        if (other.gameObject.tag == "extra")  //if player walks through an item
        {
            //Debug.Log("extra found");
            currentExtra = other.name;   //set a string name for the other scripts to work with
            //Debug.Log(currentExtra);
            score = score + 2;               //increase score
            scoreScript.UpdateScore01();       //update score
            PlayerPrefs.SetInt("IntScore", score);


            other.gameObject.SetActive(false);   //remove exra from the scene
            inventory.OnGUI();        //clear inventory field
        }
    }

    public void OnTriggerExit(Collider other)    
    {
       // Debug.Log("Increase Score");
        if (other.gameObject.tag == "Enemy")      //if player exits seeing or hearing range of an enemy
        {

            score = score + 2;                 //increase score
            PlayerPrefs.SetInt("IntScore", score); //set playerPrefs value, to not be deleted by scene changing...
            scoreScript.UpdateScore01();       // update score
        }
    }
}
