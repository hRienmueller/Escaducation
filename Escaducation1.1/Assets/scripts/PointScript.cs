using UnityEngine;
using System.Collections;

public class PointScript : MonoBehaviour
{
    public float ScoreBoost;
    public float GetHitEffect;
    private float targY;
    private Vector3 PointPosition;
    public Camera camera01;
    public float dist;
    private GameObject player;

    public GUIStyle Font;
    GUISkin PointSkin;

    private PlayerScore playerScore;

void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        PointPosition = player.transform.position;  //startposition of the score text
        playerScore = player.GetComponent<PlayerScore>();

    }

    void OnGUI()    //cannot be fully executed because extra is set inactive before this finishes... 
                    //but this is actually how it would work. 
    {
        if (playerScore.ScoreEffect == true)
        {
            //Debug.Log("targY = " + targY);
            Debug.Log("OnGUI called");
            targY = Screen.height / 2;           // y position of the score text
            Vector3 screenPos2 = camera01.WorldToScreenPoint(PointPosition);
            GetHitEffect += Time.deltaTime * 30;
            GUI.color = new Color(1.0f, 1.0f, 1.0f, 1.0f - (GetHitEffect - 50) / 7);
            GUI.skin = PointSkin;
            //GUI.Label(new Rect(screenPos2.x + 10, targY, 120, 120), "+" + ScoreBoost.ToString(), Font);
            GUI.Label(new Rect(Screen.width/2 + 10, targY, 2000, 2000), "+" + playerScore.ScoreBoost.ToString(), Font);
        }

    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        targY -= Time.deltaTime * 200;    // changes the y-position of the score text
    }
}
