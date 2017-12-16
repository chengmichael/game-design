using UnityEngine;
using System.Collections;

public class HoldItems : MonoBehaviour {

	public float speed = 10;
	public bool canHold = true;
	public Transform projectile;
	public Transform guide;

	public int score;


	int nextNameNumber = 0;
	Transform projectile_ID;



	void Start() {
		score = 0;
		Pickup ();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (!canHold) {
				throw_drop ();
			} else {
				Pickup ();
			}
		}//mause If

		if (!canHold)
			projectile.transform.position = guide.position;

	}//update

	private void Pickup()
	{

		projectile_ID = Object.Instantiate(projectile, guide.position, guide.rotation);
		projectile_ID.name = "food_" + nextNameNumber; 
		projectile_ID.GetComponent<Rigidbody>().useGravity = false;

		projectile_ID.transform.SetParent(guide);

		nextNameNumber++;

		canHold = false;
	}

	private void throw_drop()
	{
		//Set our Gravity to true again.
		projectile_ID.GetComponent<Rigidbody>().useGravity = true;
		// we don't have anything to do with our ball field anymore

		//Apply velocity on throwing
		guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

		//Unparent our ball
		guide.GetChild(0).parent = null;
		canHold = true;


	}



}//class
