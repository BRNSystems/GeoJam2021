using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Animator animator;
    public PhysicsMaterial2D top;
    public Rigidbody2D rigidbody;
    public SpriteRenderer sprite;
    public PhysicsMaterial2D bottom;
    public CharacterController2D controller;
    public float runspeed = 40f;
    float horizonatalaxis = 0f;
    bool jumping = false;
    bool switchy = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        horizonatalaxis = Input.GetAxisRaw("Horizontal");
        jumping = Input.GetButton("Jump") || Input.GetAxisRaw("Vertical") > 0;
        animator.SetFloat("Horizontal_speed", horizonatalaxis);

        if(Input.GetButtonDown("Switch")) {
            switchy = !switchy;
        }

        if (switchy){
            sprite.flipY = true;
            rigidbody.sharedMaterial = top;
        }
        else {
            sprite.flipY = false;
            rigidbody.sharedMaterial = bottom;
        }
        
    }
    void FixedUpdate(){
        controller.Move(horizonatalaxis  * runspeed * Time.fixedDeltaTime, jumping);

    }
}
