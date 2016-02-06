using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour
{
    public float numTime = 3600;   //defines how long the level takes
    Image TimeBar;                 //this is the visible part of the timer
    public int EndBonus;           //this is the bonus you get when the time runs out

    private PlayerScore playerScore;
    private Score scoreScript;

    private onButtonClick Endscript;  // reference to the OnButtonClickScript
    public AudioSource MysteriousTickingNoise;
    public AudioSource BellRinging;
    bool bellRinginPlay = false;

    void Start()
    {
        //setting the references
        MysteriousTickingNoise = GetComponent<AudioSource>();
        BellRinging = GameObject.FindGameObjectWithTag("bell").GetComponent<AudioSource>();
        Endscript = GameObject.FindGameObjectWithTag("gameController").GetComponent<onButtonClick>();
        GameObject TimeSlider = GameObject.FindGameObjectWithTag("TimeBar");
        //Debug.Log("TimeBar found");
        TimeBar = TimeSlider.GetComponent<Image>();
        // set the fillamount of the image to zero to start with a time of zero
        TimeBar.fillAmount = 0f;
        //Debug.Log("FillAmount set");
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        scoreScript = GameObject.FindGameObjectWithTag("gameController").GetComponent<Score>();
        
    }

    void FixedUpdate()
    {
        float fillPerFrame = 1 / numTime; //this makes sure,  that the TimeBarImage gets filled in the right amount of steps

        TimeBar.fillAmount = TimeBar.fillAmount + fillPerFrame;  //increases the fillamount and the timer 
        if(TimeBar.fillAmount >= 0.75 && MysteriousTickingNoise.isPlaying == false) //if the timer is at 75% and the mysteriousTickinNoise is not yet playing...
        {
            MysteriousTickingNoise.Play();   //...play the mysteriousTickingNoise
        }
        if (TimeBar.fillAmount == 1)       //if timebar is full...
        {
            scoreScript.score = scoreScript.score + EndBonus;
            PlayerPrefs.SetInt(scoreScript.NameOfScene, playerScore.score);
            PlayerPrefs.Save();
            //Debug.Log("endbonus set...");
            //Debug.Log(scoreScript.score + "+" + PlayerPrefs.GetInt(scoreScript.NameOfScene));
            if(bellRinginPlay == false)   //if the bell is not yet ringing...
            {
                BellRinging.Play();    //ring the bell
                bellRinginPlay = true;
            }

            if(BellRinging.isPlaying == false && bellRinginPlay == true)  //if the bell is not ringing anymore....
            {
                Endscript.changeScenes("StartScreen");    // jump to startScreen
            }
        }
    }
}
