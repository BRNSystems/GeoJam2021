using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public CircleCollider2D circ;
    public LayerMask LVLMask;
    public float walking_speed;
    public float jump_power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        Vector2 movement = new Vector2(0, 0);
        movement.x = walking_speed * speed;
        
        if (Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
        {
            if (circ.IsTouchingLayers(LVLMask)){
                movement.x = movement.x / 10;
                movement.y = jump_power;
            }
        }
        rb.AddRelativeForce(movement);
    }
}
