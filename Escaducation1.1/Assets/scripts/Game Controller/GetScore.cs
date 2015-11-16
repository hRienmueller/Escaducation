using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {

    Text scoreText;
    public int Number;
    private PlayerScore playerScore;

    void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("scoreCounter").GetComponent<Text>();
        playerScore = GameObject.FindGameObjectWithTag("gameController").GetComponent<PlayerScore>();
    }

    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("ScoreInt"));
        Number = playerScore.score;
        //Debug.Log(Number);
        //scoreText.text = "Score: " + Number;
    }
}
