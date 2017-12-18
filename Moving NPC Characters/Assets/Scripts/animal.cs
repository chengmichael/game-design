using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal : MonoBehaviour {
	float speed = .005f;
	Animator anim;
	Rigidbody rb;
	private bool running;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator> ();
		rb = gameObject.GetComponent<Rigidbody> ();
		anim.Play ("Run");
	}
	
	// Update is called once per frame
	void Update () {

		//rb.velocity += transform.forward *speed;
//		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Run")) {
//			rb.velocity += transform.forward * speed;	
//			running = true;
//		} else if (running) {
//			running = false;
	}

	bool AnimatorIsPlaying(){
		return anim.GetCurrentAnimatorStateInfo(0).length >
			   anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}
}
