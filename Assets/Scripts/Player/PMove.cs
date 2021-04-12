using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PMove : MonoBehaviour
{

	Transform tr;
	Animator anim;
	Rigidbody2D rb;
	SpriteRenderer render;

	public PhysicsMaterial2D WMat;
	public PhysicsMaterial2D IMat;

	public float speed = 4;
	public float jumpForse = 8.3f;
	public float koitTime = .2f;

	bool isRight = true;
	float moveX;
	bool isJumping = true;
	bool landed = false;
	Vector2 landPos;
	float landTime;

	void Start()
	{
		tr = GetComponent<Transform>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		render = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
	{
		if ((moveX = CrossPlatformInputManager.GetAxis("Horizontal")) != 0)
		{
			Walk(moveX);
		}
		else
		{
			NotWalk();
		}

		if (CrossPlatformInputManager.GetButton("Jump"))
		{
			if (!isJumping && (rb.position == landPos || landed && Time.time - landTime < koitTime) || CrossPlatformInputManager.GetButton("Fly"))
			{
				Jump();
				isJumping = true;
			}
		}
		else
		{
			isJumping = false;
		}
	}

	public void Jump()
	{
		rb.sharedMaterial = WMat;
		rb.velocity = new Vector2(rb.velocity.x, jumpForse);
		landed = false;
	}

	public void Walk(float moveX)
	{
		rb.sharedMaterial = WMat;
		rb.velocity = new Vector2(
			Mathf.Lerp(rb.velocity.x, moveX * speed, Time.deltaTime * (landed? 5f : 1f)),
			rb.velocity.y);
		anim.SetBool("IsWalking", true);
		if ((moveX > 0) != isRight) Flip();
	}

	public void NotWalk()
	{
		if (landed)
			rb.sharedMaterial = IMat;
		anim.SetBool("IsWalking", false);
		if (Mathf.Abs(rb.velocity.x) < 1f)
		{
			rb.velocity = new Vector2(0f, rb.velocity.y);
		}
	}

	void Flip ()
	{
		tr.localScale.Set(-tr.localScale.x, tr.localScale.y, tr.localScale.z);
		isRight = !isRight;
		render.flipX = !isRight;
	}

	public void OnTriggerStay2D(Collider2D collider)
	{
		landPos = rb.position;
		landTime = Time.time;
		landed = true;
	}
}
