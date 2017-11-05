using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDrag : MonoBehaviour {
	float distance = 1;
	public GameObject obj;

	void OnMouseDown() {
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Instantiate (obj, new Vector3 (0, 2, 0), Quaternion.identity);
	}

	void OnMouseDrag()
	{
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		obj.transform.position = objPosition;﻿
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag != "Table") {
			Debug.Log("collided");
			Destroy (this.gameObject);
		}
	}
}
