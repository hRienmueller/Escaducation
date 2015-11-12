using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;         //this shows your score
    private GameObject scoreCounter;  //for the reference of the scoreCounter
    private Text scoreText;       // for the reference of the text component we want to access

    //Test
    private EnemySight enemySight;  //for the reference of the enemySight script
    private PlayerScore PlayerScore; // for the reference of the playerscore script

    void Awake()
    {
        PlayerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>(); //reference to the playerscore script
        enemySight = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemySight>(); //only works, if there is just one player
        scoreCounter = GameObject.FindGameObjectWithTag("scoreCounter");   //find the scoreCounter gameObject
        scoreText = scoreCounter.GetComponent<Text>();                     //get the Text compnent of that gameobject
        Reset();                                                           //reset it at the start of the game
    }

    void FixedUpdate()
    {
        UpdateScore01();
    }

   /* void UpdateScore()  //this only works if there is just one lonely enemy... :(
    {
        if (enemySight.playerInSight ==true)    // if player is seen by the enemy...
        {
            Debug.Log("in sight true for score");
            if(score > 0)                     // ...and score is not null...
            {
                Debug.Log("score -1");
                score = score - 1;    // ...decrease score
                scoreText.text = "Score: " + score;
            }
        }
        if (enemySight.playerInSight == false)   //if player is not seen by the enemy
        {
            score = score + 1;                   // increas score
            Debug.Log("score +1");
            scoreText.text = "Score: " + score;
        }
    }*/

       public void UpdateScore01()
    {
        scoreText.text = "Score: " + PlayerScore.score;
    }

    void Reset()
    {
        score = 0;                            // resets the score
        scoreText.text = "Score: " + PlayerScore.score;   // resets the score Text
    }

    void OnTriggerEnter(Collider other)   //if player gets in seeing or hearing range of an enemy
    {
        Debug.Log("decrease score");
        if (other.gameObject.tag == "Enemy")
        {
            
            score = score - 1;    //decrease score
            UpdateScore01();        // update score
        }

        if (other.gameObject.tag == "extra")
        {
            score = score + 2;
            UpdateScore01();
        }
    }

    void OnTriggerExit(Collider other)    //if player exits seeing or hearing range of an enemy
    {
        Debug.Log("Increase Score");
        if (other.gameObject.tag == "Enemy")
        {
            
            score = score + 2;   //increase score
            UpdateScore01();       // update score
        }
    }

}
