using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
    public int speedFloat;
    public int sneakingBool;
    public int playerInSightBool;
    public int sneakState;
    public int idleState;

    public int angularSpeedFloat;
    public int locomotionState;
    public int aimweightFloat;
    public int walkState;

    //for dog
    public int barkingBool;
    public int DogSpeed;
    public int DogAngularSpeed;

    public int DogLocomotion;
    public int barkState;
    
    void Awake()
    {
        speedFloat = Animator.StringToHash("Speed");
        sneakingBool = Animator.StringToHash("Sneaking");
        playerInSightBool = Animator.StringToHash("PlayerInSight");
        sneakState = Animator.StringToHash("Base Layer.Sneak");
        idleState = Animator.StringToHash("Base Layer.Idle");

        angularSpeedFloat = Animator.StringToHash("AngularSpeed");
        locomotionState = Animator.StringToHash("Base Layer.Locomotion");
        aimweightFloat = Animator.StringToHash("Aimweight");
        walkState = Animator.StringToHash("Base Layer.Walk");

        barkingBool = Animator.StringToHash("IsBarking");
        DogSpeed = Animator.StringToHash("DogSpeed");
        DogAngularSpeed = Animator.StringToHash("DogAngularSpeed");
        DogLocomotion = Animator.StringToHash("Base Layer.DogLocomotion");
        barkState = Animator.StringToHash("Barking.DogBark");
    }
}
