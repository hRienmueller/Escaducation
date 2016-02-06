using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public void restart()
    {
        #pragma warning disable 612, 618
        Application.LoadLevel(Application.loadedLevel);
        #pragma warning restore 612, 618
    }
}
