using UnityEngine;
using System.Collections;

public class onButtonClick : MonoBehaviour {

	public void changeScenes(string NameOfScene)
    {
        #pragma warning disable 612, 618
        Application.LoadLevel(NameOfScene);
        #pragma warning restore 612, 618
    }

    public void quitScene()
    {
        Application.Quit();
    }
}
