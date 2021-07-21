using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Animator animator;
    public PhysicsMaterial2D top;
    public Rigidbody2D rb;
    public AudioClip RotateSFX;

    public SpriteRenderer sprite;
    public PhysicsMaterial2D bottom;
    public CharacterController2D controller;
    public AudioSource sfx;
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
        if(Input.GetButtonDown("Switch")) {
            switchy = !switchy;
            if (switchy){
                sprite.flipY = true;
                rb.sharedMaterial = top;
                controller.m_JumpForce = controller.m_JumpForce * 1.6f;
            }
            else {
                sprite.flipY = false;
                rb.sharedMaterial = bottom;
                controller.m_JumpForce = controller.m_JumpForce / 1.6f;
            }
            sfx.clip = RotateSFX;
            sfx.Play();
        }
        Vector3 playpos = transform.position;
        playpos.z = 0f;
        transform.position = playpos;
        if (!switchy){
        horizonatalaxis = Input.GetAxisRaw("Horizontal");
        }
        else{
            horizonatalaxis = 0;
        }
        jumping = Input.GetButton("Jump") || Input.GetAxisRaw("Vertical") > 0;
        animator.SetFloat("Horizontal_speed", horizonatalaxis);




        
    }
    void FixedUpdate(){
        controller.Move(horizonatalaxis  * runspeed * Time.fixedDeltaTime, jumping);

    }
}
