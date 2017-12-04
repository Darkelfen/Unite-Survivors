using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApfelSpawn : MonoBehaviour {

	public GameObject apfel;
	private float timer = 0f;
	private float spawnTime = 10f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= spawnTime) {
			Spawn ();
			timer = 0f;
		}
	}

	void Spawn(){
		Vector3 fruitPos = new Vector3 (this.transform.position.x + Random.Range (-1.0f, 1.0f), this.transform.position.y,this.transform.position.z + Random.Range (-1.0f, 1.0f));
		Instantiate (apfel, fruitPos, Quaternion.identity);
	}
}

