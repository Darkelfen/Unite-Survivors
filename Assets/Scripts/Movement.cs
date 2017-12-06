using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization

	public float speed = 2f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;
	Health health;
	bool objectInRange = false;
	bool isAttacking = false;
	private float soundTime = 0.3f;
	private float soundTimer = 0f;
	private float timeBetweenAttacks = 0.5f;
	private float attackTimer = 0f;


	void Awake()
	{
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();

	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		float a = Input.GetAxisRaw ("Fire2");

		Move (h, v);
		Animating (h, v);
		Attacking (a);

	}
	void OnTriggerEnter (Collider other)
	{
		health = other.GetComponent<Health>();
		objectInRange = true;
		if (other.CompareTag("Snake") && isAttacking && objectInRange)
		{
			health.TakeDamage (5);
		}
		if (other.CompareTag ("Bear") && isAttacking && objectInRange) 
		{
			health.TakeDamage (5);
		}
		if (other.CompareTag ("Tree") && isAttacking && objectInRange) 
		{
			health.TakeDamage (5);
		}
		if (other.CompareTag ("Item") && objectInRange) 
		{
			//Pickup function here
		}

	}


	void OnTriggerExit (Collider other)
	{
		objectInRange = false;
	}
	void Move( float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidBody.MovePosition (transform.position + movement);

		if (h == -1) {
			playerRigidBody.transform.rotation = Quaternion.AngleAxis (0, Vector3.up);
		} else if (h == 1) {
			playerRigidBody.transform.rotation = Quaternion.AngleAxis (180, Vector3.up);
		}
	}

	void Animating(float h, float v)
	{
		
		bool walking = h != 0f || v != 0f;
		bool facingNorth = v != -1f;
		anim.SetBool ("IsWalking", walking);
		if (walking) {
			soundTimer += Time.deltaTime;
			if (soundTimer >= soundTime) {
				AudioSource audio = GetComponent<AudioSource>();
				audio.Play();
				audio.Play(44100);
				soundTimer = 0f;
			}
		}
		if (v != 0) 
		{
			anim.SetBool ("IsFacingNorth", facingNorth);
		}
	}

	void Attacking (float a)
	{
		isAttacking = a != 0f;
		attackTimer += Time.deltaTime;
		if (timeBetweenAttacks >= attackTimer) {
			anim.SetBool ("IsAttacking",isAttacking);
		}

	}

}
