using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour {
	public int health;
	private int tHits;
	public int scoreValue;

	public float speed;
	public string targettag;

	// Use this for initialization
	void Start () {
		health = 0;
		scoreValue = 1;
		tHits = 0;
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.CompareTag (targettag))
		{
			Destroy(gameObject);
		}
		if(col.gameObject.CompareTag ("ball"))
		{
			tHits++;
		}
	}

	// Update is called once per frame
	void Update () {
		if (tHits > health) {
			Debug.Log (scoreValue);
			ScoreKeeper.score += scoreValue;
			Debug.Log ("Current score " + ScoreKeeper.score);
			Destroy (gameObject);
		}
		transform.position = Vector3.MoveTowards (transform.position, 
			GameObject.FindGameObjectWithTag(targettag).transform.position, (speed * 0.1f));
	}
}
