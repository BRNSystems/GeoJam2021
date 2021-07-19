using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;
    public float runspeed = 40f;
    float horizonatalaxis = 0f;
    bool jumping = false;
    bool crouching = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        horizonatalaxis = Input.GetAxisRaw("Horizontal");
        jumping = Input.GetButton("Jump") || Input.GetAxisRaw("Vertical") > 0;
        crouching = Input.GetButton("Crouch") || Input.GetAxisRaw("Vertical") < 0;
        animator.SetFloat("Horizontal_speed", horizonatalaxis);
        
    }

    public void crouchingx(bool stat){
        animator.SetBool("Crouching", stat);
    }
    void FixedUpdate(){
        controller.Move(horizonatalaxis  * runspeed * Time.fixedDeltaTime, crouching, jumping);

    }
}
