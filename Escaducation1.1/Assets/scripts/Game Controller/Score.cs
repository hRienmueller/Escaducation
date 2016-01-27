using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public  int score;         //this shows your score
    private GameObject scoreCounter;  //for the reference of the scoreCounter
    private Text scoreText;       // for the reference of the text component we want to access
    public string NameOfScene;

    //Test
<<<<<<< HEAD
   // private EnemySight enemySight;  //for the reference of the enemySight script
=======
    private EnemySight enemySight;  //for the reference of the enemySight script
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
    private PlayerScore PlayerScore; // for the reference of the playerscore script

    void Awake()
    {
        PlayerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>(); //reference to the playerscore script
<<<<<<< HEAD
        //enemySight = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemySight>(); //only works, if there is just one player
=======
        enemySight = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemySight>(); //only works, if there is just one player
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
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
