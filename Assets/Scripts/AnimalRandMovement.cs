using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalRandMovement : MonoBehaviour {

	public float wanderRadius;
    public float wanderTimer;
 
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
	private Animator anim;
	private Rigidbody mobRigidBody;
 
    // Use this for initialization
    void OnEnable () {
		anim = GetComponent<Animator> ();
        agent = GetComponent<NavMeshAgent> ();
        timer = wanderTimer;
		mobRigidBody = GetComponent<Rigidbody> ();
    }
 
    // Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;
		float h = 0f;
		float v = 0f;
		Vector3 oldPos = transform.position;
		Vector3 currentPos = transform.position;
        if (timer >= wanderTimer) {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0f;
			currentPos = newPos;
        }

		if (currentPos.x.Equals (oldPos.x)) {
			h = 0;
		} else {
			if (currentPos.x > oldPos.x)
				h = 1;
			if (currentPos.x < oldPos.x)
				h = -1;
		}
		if (currentPos.z.Equals (oldPos.z)) {
			v = 0;
		} else {
			if (currentPos.z < oldPos.z)
				v = 1;
			if (currentPos.z > oldPos.z)
				v = -1;
		}
		Moving (h);
		Animating (h, v);
    }
	}
 
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }

	void Moving (float h)
	{
		if (h == -1) {
			mobRigidBody.transform.rotation = Quaternion.AngleAxis (0, Vector3.up);
		} else if (h == 1) {
			mobRigidBody.transform.rotation = Quaternion.AngleAxis (180, Vector3.up);
		}
	}
	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		bool facingNorth = v != -1f;
		anim.SetBool ("IsWalking", walking);
		if (v != 0) 
		{
			anim.SetBool ("IsFacingNorth", facingNorth);
		}
	}

}
