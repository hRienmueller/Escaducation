using UnityEngine;
using System.Collections;

public class ScoreProof : MonoBehaviour
{
    public int ScoreOfLevel1;
    public int ScoreOfLevel2;
    public bool Level01scoreCheck = false;
    public bool Level02ScoreCheck = false;
    public int Level01Requiered;
    public int Level02Requiered;

    private GameObject ButtonLevel2;
    private GameObject ButtonLevel3;

    void Start()
    {

        ScoreOfLevel1 = PlayerPrefs.GetInt("Level01");
        ScoreOfLevel2 = PlayerPrefs.GetInt("Level02");

        ButtonLevel2 = GameObject.FindGameObjectWithTag("ButtonLevel02");
        ButtonLevel2.SetActive(false);

        ButtonLevel3 = GameObject.FindGameObjectWithTag("ButtonLevel03");
        ButtonLevel3.SetActive(false);
    }


    void Update()
    {
        if (ScoreOfLevel1 >= Level01Requiered)
        {
            Level01scoreCheck = true;
            Debug.Log("enough score in level 01");
        }

        if (ScoreOfLevel2 >= Level02Requiered)
        {
            Level02ScoreCheck = true;
            Debug.Log("enough score in level 02");
        }
        if (Level01scoreCheck == true)
        {
            ButtonLevel2.SetActive(true);
        }
        if (Level02ScoreCheck == true)
        {
            ButtonLevel3.SetActive(true);
        }
    }
}
