using UnityEngine;
using System.Collections;

public class ToiletScript : MonoBehaviour
{
    public bool GetScoreBoost;         //this indicates if the player had already had his fancy ToiletScoreBoost
    public int scoreBoost;             //this is the value of the ToiletScoreBoost

    private PlayerScore playerScore;   //reference to the PlayerScoreScript
    private Score scoreScript;         //reference to the ScoreScript

    void Start()
    {
        //Setting the references
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        scoreScript = GameObject.FindGameObjectWithTag("gameController").GetComponent<Score>();
    }

    void OnTriggerEnter(Collider other) // if something enters the TriggerArea...
    {
        if (GetScoreBoost == false)     //and the player did not have his fancy ToiletScoreBoost yet...
        {
            playerScore.score = playerScore.score + scoreBoost;   // the player gets the scoreBoost
            PlayerPrefs.SetInt("IntScore", playerScore.score);    //Set the Score in the PlayerPrefs
            PlayerPrefs.Save();                                   //Save the new PlayerPrefs value
            GetScoreBoost = true;      // set this to true to shw that the player already achieved his fancy ToiletScoreBoost
        }
    }
}
