using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	bool isDead = false;
	Animator anim;  
	Movement mobMovement;
	Vector3 pos;

	public GameObject meat;
	public GameObject snakeSkin;
	public GameObject bearSkin;

	void Awake()
	{
		anim = anim = GetComponent <Animator> ();	
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			
			currentHealth = 0;
			Dead ();
		}
	}

	void Dead ()
	{
		if (!isDead) {
			isDead = true;
			anim.SetTrigger ("Dead");
			mobMovement.enabled = false;
			if (this.CompareTag("Snake")) {
				pos = new Vector3 (this.transform.position.x + Random.Range (0.1f, 0.2f), this.transform.position.y, this.transform.position.z + Random.Range (0.1f, 0.2f));
				Instantiate(meat, pos, Quaternion.identity);
				pos = new Vector3 (this.transform.position.x + Random.Range (0.1f, 0.2f), this.transform.position.y, this.transform.position.z + Random.Range (0.1f, 0.2f));
				Instantiate(snakeSkin, pos, Quaternion.identity);
			}
			if (this.CompareTag ("Bear")) {
				for (int i = 0; i< Random.Range(2,5); i++)
				{
					pos = new Vector3 (this.transform.position.x + Random.Range (0.1f, 0.2f), this.transform.position.y, this.transform.position.z + Random.Range (0.1f, 0.2f));
					Instantiate(meat, pos, Quaternion.identity);
				}
				pos = new Vector3 (this.transform.position.x + Random.Range (0.1f, 0.2f), this.transform.position.y, this.transform.position.z + Random.Range (0.1f, 0.2f));
				Instantiate(meat, pos, Quaternion.identity);
				Instantiate(bearSkin, pos, Quaternion.identity);
			}
			this.Destroy ();
		}
	}
}