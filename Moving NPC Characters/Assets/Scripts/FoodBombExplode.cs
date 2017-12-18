using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBombExplode : MonoBehaviour {

	public GameObject projectile;
	private int foodSpawned = 8;
	private int foodMagnitude = 7;

	private GameObject[] food;

	// Use this for initialization
	void Awake () {
		food = new GameObject[foodSpawned];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.CompareTag ("GroundDespawn") || col.gameObject.CompareTag("NPCChar"))
		{
			Explode ();
			Destroy (gameObject);
		}

	}

	void Explode () {
		Vector3 baseVelocity = new Vector3 (0, 3, foodMagnitude);
		Vector3 basePosition = new Vector3 (0, 0, 1);
		float angle = 0;

		for (int i = 0; i < foodSpawned; i++) {
			food [i] = (GameObject)Instantiate(projectile, Quaternion.AngleAxis(angle, Vector3.up) * basePosition + transform.position, Quaternion.identity);
			food [i].GetComponent<Rigidbody> ().velocity = Quaternion.AngleAxis(angle, Vector3.up) * baseVelocity;
			food [i].GetComponent<Rigidbody> ().angularVelocity = Vector3.ClampMagnitude(GetComponent<Rigidbody> ().angularVelocity, 1); 
			angle += 360 / foodSpawned;
		}
	}
}
