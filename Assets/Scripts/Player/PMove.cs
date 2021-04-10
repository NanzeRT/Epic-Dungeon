using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public float koitDistanse = .3f;

	bool isRight = true;
	float moveX;
	bool isJumping;
	Vector2 landPos;

	void Start()
	{
		tr = GetComponent<Transform>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		render = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
	{
		if ((moveX = Input.GetAxis("Horizontal")) != 0)
		{
			Walk(moveX);
		}
		else
		{
			NotWalk();
		}

		if (Input.GetAxis("Jump") != 0)
		{
			if (!isJumping && (rb.position - landPos).magnitude < koitDistanse || Input.GetAxis("Fly") != 0)
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
		rb.velocity = new Vector2(rb.velocity.x, jumpForse);
	}

	public void Walk(float moveX)
	{
		rb.sharedMaterial = WMat;
		rb.velocity = new Vector2(
			Mathf.Lerp(rb.velocity.x, moveX * speed, Time.deltaTime * 25f),
			rb.velocity.y);
			anim.SetBool("IsWalking", true);
		if ((moveX > 0) != isRight) Flip();
	}

	public void NotWalk()
	{
		rb.sharedMaterial = IMat;
		anim.SetBool("IsWalking", false);
		if (rb.velocity.x < 1f)
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
	}
}
