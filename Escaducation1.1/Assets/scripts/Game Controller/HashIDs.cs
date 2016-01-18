using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
    public int speedFloat;                  // from enemyAnimator and playerAnimator
    public int sneakingBool;                // from playerAnimator
    public int playerInSightBool;           // from enemyAnimator
    public int sneakState;                  // from playerAnimator
    public int idleState;                   // from enemyAnimator and playerAnimator

    public int angularSpeedFloat;           // from enemyAnimator
    public int locomotionState;             // from enemyAnimator
    public int aimweightFloat;              // from enemyAnimator
    public int walkState;                   // from playerAnimator

    //for dog
    public int barkingBool;                 // from dogAnimator
    public int DogSpeed;                    // from dogAnimator
    public int DogAngularSpeed;             // from dogAnimator

    public int DogLocomotion;               // from dogAnimator
    public int barkState;                   // from dogAnimator

    public int enemySpeed;
    
    void Awake()
    {
        speedFloat = Animator.StringToHash("Speed");
        sneakingBool = Animator.StringToHash("Sneaking");
        playerInSightBool = Animator.StringToHash("PlayerInSight");
        sneakState = Animator.StringToHash("Base Layer.MainCharSneak");
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

        enemySpeed = Animator.StringToHash("enemySpeed");
    }
}
