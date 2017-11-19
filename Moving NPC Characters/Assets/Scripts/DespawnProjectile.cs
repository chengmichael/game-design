using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnProjectile : MonoBehaviour {


	public Transform Projectile;
	private float countdown = 10f;

	void Update () {
		countdown -= Time.deltaTime;
		if (countdown <= 0.0f) {
			timerEnded ();
		}
	}
	//WARNING: WILL BREAK IF PROJECTILE IN HAND SOMEHOW TOUCHES THE GROUND
	void timerEnded()
	{
		Destroy(gameObject);
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.CompareTag ("GroundDespawn"))
		{
			
			countdown = 2f;

		}

	}
}
