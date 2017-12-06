using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
	public int attackDamage = 10;               // The amount of health taken away per attack.


	Animator anim;                              // Reference to the animator component.
	GameObject player;                          // Reference to the player GameObject.
	Health1 playerHealth;                  // Reference to the player's health.
	Health enemyHealth;                    // Reference to this enemy's health.
	bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
	float timer;                                // Timer for counting up to the next attack.
	AudioSource audio;

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <Health1> ();
		enemyHealth = GetComponent<Health>();
		anim = GetComponent <Animator> ();
		audio = GetComponent<AudioSource> ();
	}


	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...

			if (other.gameObject == player) {
			
				// ... the player is in range.


				playerInRange = true;
			}
		
	}


	void OnTriggerExit (Collider other)
	{
		// If the exiting collider is the player...

			if (other.gameObject == player) 
			{
			
				// ... the player is no longer in range.
				playerInRange = false;
			}

	}
	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		if (playerHealth.currentHealth <= 0) {
			Destroy (player);
			anim.ResetTrigger ("Attack");
			audio.Stop ();
		}
		// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		else if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
		{
			Attack ();
		}

	}


	void Attack ()
	{
		// Reset the timer.
		timer = 0f;
		audio.Play ();
		// If the player has health to lose...
			anim.SetTrigger ("Attack");
			// ... damage the player.
			playerHealth.TakeDamage (attackDamage);
		// If the player has zero or less health...
		if (playerHealth.currentHealth <= 0) {
			Destroy (player);
			anim.ResetTrigger ("Attack");
			audio.Stop ();
		}
	}

}
