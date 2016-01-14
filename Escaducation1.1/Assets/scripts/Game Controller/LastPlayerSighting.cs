using UnityEngine;
using System.Collections;

public class LastPlayerSighting : MonoBehaviour {

    public Vector3 position = new Vector3(1000f, 1000f, 1000f);  //last global sighting
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f); //default position if player is out of sight
}
