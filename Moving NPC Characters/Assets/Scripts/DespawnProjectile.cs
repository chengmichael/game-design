using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnProjectile : MonoBehaviour {


	public Transform Projectile;
	public float countdown = 0f;
	public bool thrown = false;

	void Update () {
		countdown -= Time.deltaTime;
		if (countdown <= 0.0f) {
			timerEnded ();
		}
	}
	void timerEnded()
	{
		if (thrown == true) {
			Destroy(gameObject);

		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.CompareTag ("GroundDespawn"))
		{
			
			countdown = 2f;

		} 

	}
}
