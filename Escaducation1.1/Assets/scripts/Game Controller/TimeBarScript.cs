using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour
{
    public float numTime = 3600;
    Image TimeBar;

    private onButtonClick Endscript;

    void Start()
    {
        Endscript = GameObject.FindGameObjectWithTag("gameController").GetComponent<onButtonClick>();
        GameObject TimeSlider = GameObject.FindGameObjectWithTag("TimeBar");
        TimeBar = TimeSlider.GetComponent<Image>();
        TimeBar.fillAmount = 0f;
        
    }

    void FixedUpdate()
    {
        float fillPerFrame = 1 / numTime;

        TimeBar.fillAmount = TimeBar.fillAmount + fillPerFrame;
        if (TimeBar.fillAmount == 1)
        {
            Endscript.changeScenes("StartScreen");
        }
    }
}
