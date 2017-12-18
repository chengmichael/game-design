using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	private GameObject collidingObject; 
	private GameObject objectInHand; 
	private float shotCooldown = 1.5f;
	private float speed = 20;
	private bool canHold = true;
	private bool shootMode = true; 
	public GameObject projectile;
	public Transform hand;

	int nextNameNumber = 0;


	private SteamVR_Controller.Device Controller {
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake(){
		SpawnObject ();
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	private void SetCollidingObject(Collider col) {
		if (collidingObject || !col.GetComponent<Rigidbody>()) {
			return;
		}
		collidingObject = col.gameObject;
	}

	public void OnTriggerEnter(Collider other) {
		SetCollidingObject(other);
	}

	public void OnTriggerStay(Collider other) {
		SetCollidingObject(other);
	}

	public void OnTriggerExit(Collider other) {
		if (!collidingObject) {
			return;
		}
		collidingObject = null;
	}

	private void GrabObject() {
		objectInHand = collidingObject;
		collidingObject = null;
		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
	}

	private void SpawnObject() {
		objectInHand = Instantiate(projectile, hand.position, Quaternion.LookRotation(hand.forward)) as GameObject;
		objectInHand.name = "food_" + nextNameNumber; 
		//objectInHand.GetComponent<Rigidbody>().useGravity = false;

		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

		nextNameNumber++;
	}

	private FixedJoint AddFixedJoint() {
		FixedJoint fx = gameObject.AddComponent<FixedJoint>();
		fx.breakForce = 20000;
		fx.breakTorque = 20000;
		return fx;
	}

	private void ReleaseObject() {
		if (GetComponent<FixedJoint>()) {
			GetComponent<FixedJoint>().connectedBody = null;
			Destroy(GetComponent<FixedJoint>());
			objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity * 3f;
			objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity * 0.75f;
		}
		objectInHand = null;
	}

	private void ShootObject() {
		if (GetComponent<FixedJoint>()) {
			GetComponent<FixedJoint>().connectedBody = null;
			Destroy(GetComponent<FixedJoint>());
			objectInHand.GetComponent<Rigidbody>().velocity = hand.forward * speed;
			objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity * 0.75f;
		}
		objectInHand = null;
	}

	private void clearHand() {
		//trying to destroy all food objects in hand
		if (collidingObject) {
			if (collidingObject.tag == "food") {
				Destroy (collidingObject);
				//SetCollidingObject ();
			} 
		}
		if (objectInHand) {
			if (objectInHand.tag == "food") {
				Destroy (objectInHand);
			} 
		}
//		if (collidingObject.tag == "food") {
//			Destroy (collidingObject);
//		}
	}

	// Update is called once per frame
	void Update () {
		

		if (shootMode) {
			if (Controller.GetPressDown (SteamVR_Controller.ButtonMask.Grip)) {
				shootMode = false;
				clearHand ();
			}

			shotCooldown -= Time.deltaTime;
			if (shotCooldown <= 0.0f) {
				if (objectInHand) {
					if (Controller.GetHairTriggerDown ()) {
						ShootObject ();
						shotCooldown = .75f;
					}
				} else {
					SpawnObject ();
				}
			}
		} else {
			if (Controller.GetPressDown (SteamVR_Controller.ButtonMask.Grip)) {
				shootMode = true;
				clearHand ();
			}

			if (Controller.GetHairTriggerDown()) {
				if (collidingObject) {
					GrabObject();
				}
			}

			if (Controller.GetHairTriggerUp()) {
				if (objectInHand) {
					ReleaseObject();
				}
			}
		}
	}
}
