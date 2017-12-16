using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float speed = .25f;
	Animator anim;
	Rigidbody rigidbody;
	float JumpSpeed = 25f;

	void Start(){
		anim = gameObject.GetComponentInChildren<Animator>();
		rigidbody =gameObject.GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		if (Input.GetKey ("w")) {
			rigidbody.velocity += transform.forward * speed;
			anim.SetBool ("walk", true);
		} else if (Input.GetKey ("s")) {
			rigidbody.velocity += transform.forward * -1 * speed;
			anim.SetBool ("walk", true);
		} else if (Input.GetKey ("a")) {
			rigidbody.velocity += transform.right * -1 * speed;
			anim.SetBool ("walk", true);
		} else if (Input.GetKey ("d")) {
			rigidbody.velocity += transform.right * speed;
			anim.SetBool ("walk", true);
		} else if (Input.GetKey("space")){
			anim.SetTrigger("jump");
			rigidbody.AddForce (Vector3.up * JumpSpeed);
		} else {
			anim.SetBool ("walk", false);
			rigidbody.velocity = new Vector3(0,rigidbody.velocity.y,0);
		}}}
