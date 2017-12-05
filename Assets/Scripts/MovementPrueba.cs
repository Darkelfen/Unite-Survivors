﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPrueba : MonoBehaviour {

	public float speed = 2f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;

	private float soundTime = 0.3f;
	private float soundTimer = 0f;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();

	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("HorizontalP2");
		float v = Input.GetAxisRaw ("VerticalP2");
		float a = Input.GetAxisRaw ("Fire1");

		Move (h, v);
		Animating (h, v);
		Attacking (a);
	}

	void Move( float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidBody.MovePosition (transform.position + movement);

		if (h == -1) 
		{
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
		bool attack = a != 0f;
		anim.SetBool ("IsAttacking",attack);
	}
}
