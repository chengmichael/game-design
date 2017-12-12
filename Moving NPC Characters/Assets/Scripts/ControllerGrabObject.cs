using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	private GameObject collidingObject; 
	private GameObject objectInHand; 
	private float shotCooldown = 1.5f;

	public float speed = 15;
	public bool canHold = true;
	public GameObject projectile;
	public Transform hand;

	public int score;

	int nextNameNumber = 0;


	private SteamVR_Controller.Device Controller {
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake(){
		score = 0;
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
		objectInHand.name = "p" + nextNameNumber; 
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

	// Update is called once per frame
	void Update () {
		//		if (Controller.GetHairTriggerDown()) {
		//			if (collidingObject) {
		//				GrabObject();
		//			}
		//		}
		//
		//		if (Controller.GetHairTriggerUp()) {
		//			if (objectInHand) {
		//				ReleaseObject();
		//			}
		//		}

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
	}
}
