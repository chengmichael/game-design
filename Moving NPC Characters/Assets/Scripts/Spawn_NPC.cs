using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_NPC : MonoBehaviour {

	public float respawn_interval;
	public Transform SpawnedChar;

	private float countdown = 2.0f;



	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if (countdown <= 0.0f) {
			timerEnded ();
		}
	}
		

	void timerEnded()
	{
		countdown = respawn_interval;
		Object.Instantiate (SpawnedChar, transform.position, transform.rotation);
	}
}
