using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
<<<<<<< HEAD
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
=======
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
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
    
    void Awake()
    {
        speedFloat = Animator.StringToHash("Speed");
        sneakingBool = Animator.StringToHash("Sneaking");
        playerInSightBool = Animator.StringToHash("PlayerInSight");
<<<<<<< HEAD
        sneakState = Animator.StringToHash("Base Layer.MainCharSneak");
=======
        sneakState = Animator.StringToHash("Base Layer.Sneak");
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
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
<<<<<<< HEAD

        enemySpeed = Animator.StringToHash("enemySpeed");
=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
    }
}
