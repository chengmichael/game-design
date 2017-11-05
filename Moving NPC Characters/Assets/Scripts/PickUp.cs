using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
	public GameObject obj;
	bool respawn;

	void Start() {
		respawn = false;
	}

	void OnMouseDown() {
		Debug.Log (respawn);
		if (respawn) 
			Instantiate (obj, new Vector3(-7.73f, 1.361f, 0f), Quaternion.identity);

		respawn = !respawn;
	}
}
