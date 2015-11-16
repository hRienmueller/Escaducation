using UnityEngine;
using System.Collections;

public class onButtonClick : MonoBehaviour {

	public void changeScenes(string NameOfScene)
    {
        Application.LoadLevel(NameOfScene);
    }
}
