using UnityEngine;
using System.Collections;

public class ToiletScript : MonoBehaviour
{
    public bool GetScoreBoost;
    public int scoreBoost;

    private PlayerScore playerScore;
    private Score scoreScript;

    void Start()
    {
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        scoreScript = GameObject.FindGameObjectWithTag("gameController").GetComponent<Score>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (GetScoreBoost == false)
        {
            playerScore.score = playerScore.score + scoreBoost;
            PlayerPrefs.SetInt("IntScore", playerScore.score);
            PlayerPrefs.Save();
            GetScoreBoost = true;
        }
    }
}
