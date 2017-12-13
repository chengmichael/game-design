using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour {
	public int health;
	private int tHits;
	public int scoreValue;

	public float speed;
	public string targettag;
	private int curr_randnum;
	private int randnum;
	private string targetname;
	private float basespeed = 0.1f;
	//private float countdown = 0f;
	public AudioClip eatingsound;

	// Use this for initialization
	void Start () {
		health = 0;
		scoreValue = 1;
		tHits = 0;
		randnum = Random.Range (0, 4);
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = eatingsound;

	}




	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.CompareTag (targettag)) {
			Destroy (gameObject);
			GameObject.Find ("Canvas").GetComponent<HealthBar> ().barDisplay -= 0.1f;
		} else if (col.gameObject.name == targetname) {
			curr_randnum = randnum;
			while (randnum == curr_randnum) {
				randnum = Random.Range (0, 4);
			}
		}
			
			
		if(col.gameObject.CompareTag ("ball"))
		{
			AudioSource.PlayClipAtPoint (eatingsound, transform.position);
			tHits++;
		}
	}

	// Update is called once per frame
	void Update () {
		if (tHits > health) {
			ScoreKeeper.score += scoreValue;

			Destroy (gameObject);

		}

		if (randnum == 0) {
			targetname = "Waypoint1";
		} else if (randnum == 1) {
			targetname = "Waypoint2";
		} else if (randnum == 2) {
			targetname = "Waypoint3";
		} else if (randnum == 3) {
			targetname = "WaypointFinal";
		}

		transform.position = Vector3.MoveTowards (transform.position, 
			GameObject.Find (targetname).transform.position, (speed * basespeed));
		
		Vector3 targetdir = GameObject.Find (targetname).transform.position - transform.position;

		transform.rotation = Quaternion.LookRotation (targetdir);
			//GameObject.FindGameObjectWithTag(targettag).transform.position, (speed * 0.1f));



	}



}
