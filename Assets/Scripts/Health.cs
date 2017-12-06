using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	Vector3 pos;

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			
			currentHealth = 0;
		}
	}

	void FixedUpdate()
	{
		if (currentHealth <= 0)
			Drop ();
	}

	void Drop (){
		if (gameObject.name == "Bear") {
		}
		if (gameObject.name == "Snake") {
		}
		if (gameObject.name == "Tree") {
		}
		Destroy (gameObject);
	}
}