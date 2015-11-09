using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
    public int speedFloat;
    public int sneakingBool;
    //public int playerInSightBool;
    
    void Awake()
    {
        speedFloat = Animator.StringToHash("Speed");
        sneakingBool = Animator.StringToHash("Sneaking");
        //playerInSightBool = Animator.StringToHash("PlayerInSight");
    }
}
