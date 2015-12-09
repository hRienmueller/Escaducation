﻿using UnityEngine;
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
    //test
    public float GetHitEffect;
    private float targY;
    private Vector3 PointPosition;
    public Camera camera01;

    public GUIStyle Font;
    GUISkin PointSkin;
    public bool ScoreEffect;    //should the score effect be played?
    float effectTimer;

    private PointScript pointScript;
    private GameObject player;
    public float PlayerPosX;

    void Awake()
    {
        ScoreEffect = false;
        effectTimer = 0;
        player = GameObject.FindGameObjectWithTag("Player");

        currentExtra = "   ";
        inventory = GameObject.FindGameObjectWithTag("gameController").GetComponent<InventoryScript>();
        scoreScript = GameObject.FindGameObjectWithTag("gameController").GetComponent<Score>();
        pointScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PointScript>();
    }

    public void Update()
    {
        //targY -= Time.deltaTime * 200;    // changes the y-position of the score text
        PlayerPosX = player.transform.position.x;
        countTimer += Time.deltaTime;
        if (countTimer >= countMaxTime)
        {
            ScoreBoost = 20;
            ScoreEffect = true;

            score = score + ScoreIncreasePerTime;
            countTimer = 0f;
            PlayerPrefs.SetInt(scoreScript.NameOfScene, score);
        }


        //Debug.Log("score effect = " + ScoreEffect);

        if (ScoreEffect == true)
        {
            effectTimer = effectTimer + Time.deltaTime;

            if (effectTimer >=1)
            {
                ScoreEffect = false;
                effectTimer = 0;
                pointScript.GetHitEffect = 0;
            }
        }
    }

    public void OnTriggerEnter(Collider other)  
    {
        //Debug.Log("decrease score");
        if (other.gameObject.tag == "Enemy")     //if player gets in seeing or hearing range of an enemy
        {
            ScoreBoost = -1;
            ScoreEffect = true;

            score = score - ScoreDecreaseBySight;    //decrease score
            scoreScript.UpdateScore01();        // update score
            PlayerPrefs.SetInt(scoreScript.NameOfScene, score);
        }

        if (other.gameObject.tag == "extra")  //if player walks through an item
        {
            ScoreBoost = 2;
            ScoreEffect = true;
            //Debug.Log(ScoreEffect);

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
            ScoreEffect = true;

            score = score + 2*ScoreDecreaseBySight;                 //increase score
            PlayerPrefs.SetInt(scoreScript.NameOfScene, score); //set playerPrefs value, to not be deleted by scene changing...
            scoreScript.UpdateScore01();       // update score
        }
    }
}
