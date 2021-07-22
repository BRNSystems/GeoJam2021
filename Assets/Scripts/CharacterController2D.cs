using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	public float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	
    public AudioSource SFX;
	public AudioClip JumpSFX;
	public LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	public Transform m_GroundCheck;							// A position marking where to check if the player is grounded.

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

	}

	private void FixedUpdate()
	{
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
			}
		}
	}


	public void Move(float move, bool jump)
	{

		// Move the character by finding the target velocity

		Vector3 targetVelocity = m_Rigidbody2D.velocity;
		targetVelocity[0] = move * 10f;
		m_Rigidbody2D.velocity = targetVelocity;

		// If the player should jump...
		if (m_Grounded && jump)
		{
			m_Grounded = false;
			targetVelocity = m_Rigidbody2D.velocity;
			targetVelocity[1] = m_JumpForce;
			m_Rigidbody2D.velocity = targetVelocity;
			SFX.clip = JumpSFX;
			SFX.Play();
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
