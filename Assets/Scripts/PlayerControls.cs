using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public CharacterController2D controller;
    public float runspeed = 40f;
    float horizonatalmove = 0f;
    bool jumping = false;
    bool crouching = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizonatalmove = Input.GetAxisRaw("Horizontal") * runspeed;
        jumping = Input.GetButton("Jump") || Input.GetAxisRaw("Vertical") > 0;
        crouching = Input.GetButton("Crouch") || Input.GetAxisRaw("Vertical") < 0;
        
    }

    void FixedUpdate(){
        controller.Move(horizonatalmove * Time.fixedDeltaTime, crouching, jumping);

    }
}
