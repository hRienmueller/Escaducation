using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    private Text scoreText;
    private int score;
    private GameObject ScoreCounter;

    void Start()
    {
        score = PlayerPrefs.GetInt("IntScore");
        scoreText = GameObject.FindGameObjectWithTag("scoreCounter").GetComponent<Text>();
        scoreText.text = "Score: " + score;
    }
}
