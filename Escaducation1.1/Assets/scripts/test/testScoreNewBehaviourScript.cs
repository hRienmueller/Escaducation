using UnityEngine;
using System.Collections;

public class testScoreNewBehaviourScript : MonoBehaviour
{
    public int TestScore;
    public string NameOfScoreStorage;

    void Start()
    {
        TestScore = 0;
        PlayerPrefs.SetInt(NameOfScoreStorage, 0);
        PlayerPrefs.Save();
    }

   public void Click()
    {
        TestScore = TestScore + 2;
        PlayerPrefs.SetInt(NameOfScoreStorage, TestScore);
        PlayerPrefs.Save();
    }
}
