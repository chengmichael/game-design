using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnProjectile : MonoBehaviour {

	private float countdown = 2f;
	private bool timerOn = false; 

	void Update () {
		if (timerOn) {
			countdown -= Time.deltaTime;
			if (countdown <= 0.0f) {
				timerEnded ();
			}
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
			
			timerOn = true;

		}

	}
}
