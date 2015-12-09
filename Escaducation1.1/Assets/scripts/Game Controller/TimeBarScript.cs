using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour
{
    public float numTime = 3600;   //defines how long the level takes
    Image TimeBar;                 //this is the visible part of the timer
    public int EndBonus;

    private PlayerScore playerScore;
    private Score scoreScript;

    private onButtonClick Endscript;  // reference to the OnButtonClickScript

    void Start()
    {
        //setting the references
        Endscript = GameObject.FindGameObjectWithTag("gameController").GetComponent<onButtonClick>();
        GameObject TimeSlider = GameObject.FindGameObjectWithTag("TimeBar");
        TimeBar = TimeSlider.GetComponent<Image>();
        // set the fillamount of the image to zero to start with a time of zero
        TimeBar.fillAmount = 0f;
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        scoreScript = GameObject.FindGameObjectWithTag("gameController").GetComponent<Score>();
        
    }

    void FixedUpdate()
    {
        float fillPerFrame = 1 / numTime; //this makes sure,  that the TimeBarImage gets filled in the right amount of steps

        TimeBar.fillAmount = TimeBar.fillAmount + fillPerFrame;  //increases the fillamount and the timer 
        if (TimeBar.fillAmount == 1)       //if timebar is full...
        {
            scoreScript.score = scoreScript.score + EndBonus;
            PlayerPrefs.SetInt(scoreScript.NameOfScene, playerScore.score);
            PlayerPrefs.Save();
            Debug.Log("endbonus set...");
            Debug.Log(scoreScript.score + "+" + PlayerPrefs.GetInt(scoreScript.NameOfScene));
            Endscript.changeScenes("StartScreen");    // jump to startScreens
        }
    }
}
