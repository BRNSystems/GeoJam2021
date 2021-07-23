using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	public float m_JumpVelocity = 20f;
    public AudioSource SFX;
	public AudioClip JumpSFX;
	public LayerMask GroundLayer;
	public Transform GroundCheckElement;
	public float GroundCheckRadius = 0.2f;
	bool OnGround;
	public Rigidbody2D rb;

	bool wasOnGround = false;

	bool CanJump = false;

	private void FixedUpdate()
	{
		wasOnGround = OnGround;
		if (Physics2D.CircleCast(GroundCheckElement.position, GroundCheckRadius, Vector2.zero, 0f, GroundLayer))
		{
			OnGround = true;
		}
		else{
			OnGround = false;
		}
		if (wasOnGround != OnGround && OnGround == true){
			CanJump = true;
		}
	}


	public void Move(float move, bool jump)
	{

		Vector3 targetVelocity = rb.velocity;
		targetVelocity[0] = move;
		rb.velocity = targetVelocity;

		if (OnGround && jump && CanJump)
		{
			OnGround = false;
			targetVelocity = rb.velocity;
			targetVelocity[1] = m_JumpVelocity;
			rb.velocity = targetVelocity;
			SFX.clip = JumpSFX;
			SFX.Play();
		}
	}
}
