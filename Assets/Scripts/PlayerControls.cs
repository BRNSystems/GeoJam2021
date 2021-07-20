using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Animator animator;
    public PhysicsMaterial2D top;
    public Rigidbody2D rigidbody;
    public PhysicsMaterial2D bottom;
    public CharacterController2D controller;
    public float runspeed = 40f;
    float horizonatalaxis = 0f;
    bool jumping = false;
    bool crouching = false;
    bool switchy = false;

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
        switchy = Input.GetButton("Switch");
        if (switchy){
            transform.rotation = new Quaternion(0f, 0f, 180f, 0f);
            rigidbody.sharedMaterial = top;
        }
        else {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            rigidbody.sharedMaterial = bottom;
        }
        
    }

    public void crouchingx(bool stat){
        //animator.SetBool("Crouching", stat);
    }
    void FixedUpdate(){
        controller.Move(horizonatalaxis  * runspeed * Time.fixedDeltaTime, false, jumping);

    }
}
