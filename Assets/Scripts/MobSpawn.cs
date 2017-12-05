using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour {

	public GameObject apfel;
	public GameObject Tree;
	public GameObject Oso;
	public GameObject Snake;
	private float apfelTimer = 0f;
	private float treeTimer = 0f;
	private float osoTimer = 0f;
	private float snakeTimer = 0f;
	private float apfelTime = 3f;
	private float treeTime = 3f;
	private float osoTime = 3f;
	private float snakeTime = 3f;
	private int type;
	private Vector3 Pos;
	// Use this for initialization
	void Start () {
		MakeForest ();

	}

	// Update is called once per frame
	void Update () {
		apfelTimer += Time.deltaTime;
		treeTimer += Time.deltaTime;
		osoTimer += Time.deltaTime;
		snakeTimer += Time.deltaTime;
		if (apfelTimer >= apfelTime) {
			type = 0;
			Spawn (type);
			apfelTimer = 0f;
		}
	
		if (osoTimer >= osoTime) {
			type = 2;
			Spawn (type);
			osoTimer = 0f;
		}

		if (snakeTimer >= snakeTime) {
			type = 3;
			Spawn (type);
			snakeTimer = 0f;
		}
	}

	void Spawn(int type){
		switch (type) {
		case 0:
			Pos = new Vector3(this.transform.position.x + Random.Range (-500f, 500f), 0.1f, this.transform.position.z + Random.Range (-500f, 500f));
			Instantiate (apfel, Pos, Quaternion.identity);
			break;
		case 2:
			Pos = new Vector3(this.transform.position.x + Random.Range (-500f, 500f), this.transform.position.y, this.transform.position.z + Random.Range (-500f, 500f));
			Instantiate (Oso, Pos, Quaternion.identity);
			break;
		case 3:
			Pos = new Vector3(this.transform.position.x + Random.Range (-500f, 500f), this.transform.position.y, this.transform.position.z + Random.Range (-500f, 500f));
			Instantiate (Snake, Pos, Quaternion.identity);
			break;
		default:
			break;
		}

	}

	void MakeForest ()
	{
		/*
		float spawnChance = 30f;
		for (int i = 0; i < 500; i++) {
			for (int j = 0; j < 500; j++) {
				if (spawnChance < Random.Range (0f, 100f)) {
					Pos = new Vector3 (i, 0.4f, j);
					Instantiate (Tree, Pos, Quaternion.identity);
				}
			}
		}
		*/
	}
}