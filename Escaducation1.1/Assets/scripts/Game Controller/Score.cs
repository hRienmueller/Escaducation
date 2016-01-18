﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public  int score;         //this shows your score
    private GameObject scoreCounter;  //for the reference of the scoreCounter
    private Text scoreText;       // for the reference of the text component we want to access
    public string NameOfScene;

    //Test
   // private EnemySight enemySight;  //for the reference of the enemySight script
    private PlayerScore PlayerScore; // for the reference of the playerscore script

    void Awake()
    {
        PlayerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>(); //reference to the playerscore script
        //enemySight = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemySight>(); //only works, if there is just one player
        scoreCounter = GameObject.FindGameObjectWithTag("scoreCounter");   //find the scoreCounter gameObject
        scoreText = scoreCounter.GetComponent<Text>();                     //get the Text compnent of that gameobject
        if (NameOfScene != "StartScreen") //this does not work as I want it to.
        {
            Reset();
        }//reset it at the start of the level
    }

    void FixedUpdate()
    {
        UpdateScore01();
        //Debug.Log(PlayerPrefs.GetInt("IntScore"));
    }


       public void UpdateScore01()
    {
        scoreText.text = "Score: " + PlayerScore.score;
        PlayerPrefs.SetInt("ScoreInt", PlayerScore.score);
        PlayerPrefs.SetInt(NameOfScene, PlayerScore.score);
        PlayerPrefs.Save();
    }

    void Reset()
    {
        score = 0;                            // resets the score
        scoreText.text = "Score: " + PlayerScore.score;   // resets the score Text
    }
}
