using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    private Text scoreText00;
    private int score00;

    private Text scoreText01;
    private int score01;

    private Text scoreText02;
    private int score02;

    private Text scoreText03;
    private int score03;

    void Start()
    {
        /*score00 = PlayerPrefs.GetInt("IntScore");
        scoreText00 = GameObject.FindGameObjectWithTag("scoreCounter").GetComponent<Text>();
        scoreText00.text = "Try Score: " + score00;*/

        score01 = PlayerPrefs.GetInt("Level01");
        scoreText01 = GameObject.FindGameObjectWithTag("scoreCounter01").GetComponent<Text>();
        scoreText01.text = "Level 01 Score: " + score01;

        score02 = PlayerPrefs.GetInt("Level02");
        scoreText02 = GameObject.FindGameObjectWithTag("scoreCounter02").GetComponent<Text>();
        scoreText02.text = "Level 02 Score: " + score02;

        score03 = PlayerPrefs.GetInt("Level03");
        scoreText03 = GameObject.FindGameObjectWithTag("scoreCounter03").GetComponent<Text>();
        scoreText03.text = "Level 03 Score: " + score03;
    }
}
