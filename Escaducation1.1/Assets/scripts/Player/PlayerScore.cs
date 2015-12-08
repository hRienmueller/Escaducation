using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    public int score;

    public int ScoreIncreasePerTime;
    public int ScoreDecreaseBySight;
    public int ScoreIncreaseExtra;

    public string currentExtra;
    public float countMaxTime;

    private Score scoreScript;
    private InventoryScript inventory;
    private float countTimer;

    public float ScoreBoost;
    public float GetHitEffect;
    private float targY;
    private Vector3 PointPosition;
    public Camera camera01;

    public GUIStyle Font;
    GUISkin PointSkin;


    void Awake()
    {
        currentExtra = "   ";
        inventory = GameObject.FindGameObjectWithTag("gameController").GetComponent<InventoryScript>();
        scoreScript = GameObject.FindGameObjectWithTag("gameController").GetComponent<Score>();
    }

    public void Update()
    {
        targY -= Time.deltaTime * 200;    // changes the y-position of the score text
        countTimer += Time.deltaTime;
        if (countTimer >= countMaxTime)
        {
            score = score + ScoreIncreasePerTime;
            countTimer = 0f;
            PlayerPrefs.SetInt(scoreScript.NameOfScene, score);
        }
    }

    public void OnTriggerEnter(Collider other)  
    {
        //Debug.Log("decrease score");
        if (other.gameObject.tag == "Enemy")     //if player gets in seeing or hearing range of an enemy
        {
            ScoreBoost = -1;
            score = score - ScoreDecreaseBySight;    //decrease score
            scoreScript.UpdateScore01();        // update score
            PlayerPrefs.SetInt(scoreScript.NameOfScene, score);
        }

        if (other.gameObject.tag == "extra")  //if player walks through an item
        {
            ScoreBoost = 2;
            //Debug.Log("extra found");
            currentExtra = other.name;   //set a string name for the other scripts to work with
            //Debug.Log(currentExtra);
            score = score + ScoreIncreaseExtra;               //increase score
            scoreScript.UpdateScore01();       //update score
            PlayerPrefs.SetInt(scoreScript.NameOfScene, score);



            other.gameObject.SetActive(false);   //remove exra from the scene
            //Debug.Log("extra inactive");
            inventory.OnGUI();        //clear inventory field
        }
    }

    public void OnTriggerExit(Collider other)    
    {
       // Debug.Log("Increase Score");
        if (other.gameObject.tag == "Enemy")      //if player exits seeing or hearing range of an enemy
        {
            ScoreBoost = 2;
            score = score + 2*ScoreDecreaseBySight;                 //increase score
            PlayerPrefs.SetInt(scoreScript.NameOfScene, score); //set playerPrefs value, to not be deleted by scene changing...
            scoreScript.UpdateScore01();       // update score
        }
    }

    /*void OnGUI()   
    {
        if (?????)  //something that does not depend on anything of the extra for it will be set to inactive and be therefore not accessable anymore.
        {
            targY = Screen.height / 2;           // y position of the score text
            Vector3 screenPos2 = camera01.WorldToScreenPoint(PointPosition);
            GetHitEffect += Time.deltaTime * 30;
            GUI.color = new Color(1.0f, 1.0f, 1.0f, 1.0f - (GetHitEffect - 50) / 7);
            GUI.skin = PointSkin;
            GUI.Label(new Rect(screenPos2.x + 10, targY, 120, 120), ScoreBoost.ToString(), Font);
        }

    }*/
}
