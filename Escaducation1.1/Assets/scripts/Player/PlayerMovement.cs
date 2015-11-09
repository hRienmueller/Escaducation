using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float turnSmoothing = 15f;
    public float speedDampTime = 0.1f;

    private Animator anim;
    private HashIDs hash;
    private Rigidbody rigidbody;

    void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("gameController").GetComponent<HashIDs>() ;

        rigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool sneak = Input.GetButton("Sneak");

        MovementManagement(h, v, sneak);
    }

    void MovementManagement(float horizontal, float vertical, bool sneaking)
    {
        anim.SetBool(hash.sneakingBool, sneaking);

        if (horizontal != 0f || vertical != 0f)
        {
            Rotating(horizontal, vertical);
            anim.SetFloat(hash.speedFloat, 1f, speedDampTime, Time.deltaTime);
        }
        else
        {
            anim.SetFloat(hash.speedFloat, 0);
        }
    }

    void Rotating(float horizontal, float vertical)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing*Time.deltaTime);
        rigidbody.MoveRotation(newRotation);
    }
}
