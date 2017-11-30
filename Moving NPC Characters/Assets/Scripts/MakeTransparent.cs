using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		gameObject.GetComponent<Renderer> ().material.color= 
			new Color(1.0f,1.0f,1.0f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
