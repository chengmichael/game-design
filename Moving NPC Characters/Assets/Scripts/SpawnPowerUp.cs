using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour {

	public GameObject powerUp;
	private float countdown = 10f;
	private int maxPowerUps = 3;
	private int existingPowerUps;

	private GameObject[] powerUps;
	private Vector3 heightSpawn = new Vector3(0, 1, 0);

	// Use this for initialization
	void Start () {
		existingPowerUps = 0;
		powerUps = new GameObject[maxPowerUps];
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if (countdown <= 0.0f && existingPowerUps < maxPowerUps) {
			powerUps [existingPowerUps] = (GameObject)Instantiate (powerUp, (transform.position + heightSpawn), Quaternion.identity);
			existingPowerUps += 1;
			countdown = 10f;
		}
	}
}
