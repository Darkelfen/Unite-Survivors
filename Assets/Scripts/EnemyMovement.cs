using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour {

	Transform player;   
	Transform player2; // Reference to the player's position.
	Health1 playerHealth; 
	Health1 playerHealth2; // Reference to the player's health.
	Health enemyHealth;        // Reference to this enemy's health.
	NavMeshAgent nav;               // Reference to the nav mesh agent.
	Animator anim;
	int i;
	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		player2 = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <Health1> ();
		playerHealth2 = player.GetComponent <Health1> ();
		enemyHealth = GetComponent <Health> ();
		nav = GetComponent <NavMeshAgent> ();
		anim = GetComponent<Animator> ();
	}


	void Update ()
	{
		
		// If the enemy and the player have health left...
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
			// ... set the destination of the nav mesh agent to the player.
			anim.SetBool("IsWalking",true);
			nav.SetDestination (player.position);
		}
		// Otherwise...
		else
		{
		// ... disable the nav mesh agent.
			nav.enabled = false;

		}
		/*if(enemyHealth.currentHealth > 0 && playerHealth2.currentHealth > 0)
		{
			// ... set the destination of the nav mesh agent to the player.
			anim.SetBool("IsWalking",true);
			nav.SetDestination (player2.position);
		}
		// Otherwise...
		else
		{
			// ... disable the nav mesh agent.
			nav.enabled = false;

		}
		*/
	} 

}
