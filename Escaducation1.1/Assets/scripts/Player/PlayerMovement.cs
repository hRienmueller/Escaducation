﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float turnSmoothing = 15f;   //smoothing value for turning the player
    public float speedDampTime = 0.1f;   //a damping for the speed parameter

    private Animator anim;         //referencing the Player animator
    private HashIDs hash;          //referencing the HashIds script
    private Rigidbody rigidbody;   //referencing the rigidboy

<<<<<<< HEAD
    public GameObject Player;
    private Vector3 targetDirection;



    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>() ;

        rigidbody = Player.GetComponent<Rigidbody>();
=======
    void Awake()
    {

        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>() ;

        rigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
    }

    void FixedUpdate()
    {
        //cache the inputs
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool sneak = Input.GetButton("Sneak");

        MovementManagement(h, v, sneak);
<<<<<<< HEAD

        


=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
    }

    void MovementManagement(float horizontal, float vertical, bool sneaking)
    {
        anim.SetBool(hash.sneakingBool, sneaking);  //set the sneaking parameter to the sneak input
        if (horizontal != 0f || vertical != 0f)  // if there is some axis input...
        {
            Rotating(horizontal, vertical);   //set players rotation
            anim.SetFloat(hash.speedFloat, 1f, speedDampTime, Time.deltaTime);  // set players speed
<<<<<<< HEAD

=======
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
        }
        else
        {
            anim.SetFloat(hash.speedFloat, 0); //if there is no input, set the speed of the player to zero.
        }
    }

    void Rotating(float horizontal, float vertical)  //calculate the players rotation based on the axis input
    {
<<<<<<< HEAD
        targetDirection = new Vector3(horizontal, 0f, vertical); //Create a new Vector of the orizontal and vertical inputs
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);  // create a rotation based on theis Vector assuming that up is the global y axis
        Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing*Time.deltaTime);    // Create a rotation that is an increment closer to the target rotation from the player's rotation.
        rigidbody.MoveRotation(newRotation); //change te players rotation to this new rotation vector

        
=======
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical); //Create a new Vector of the orizontal and vertical inputs
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);  // create a rotation based on theis Vector assuming that up is the global y axis
        Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing*Time.deltaTime);    // Create a rotation that is an increment closer to the target rotation from the player's rotation.
        rigidbody.MoveRotation(newRotation); //change te players rotation to this new rotation vector
>>>>>>> dd5711ced731f99b586cb33f83b71c58174c8409
    }
}
