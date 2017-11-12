using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	private Text scoreText;
	public static int score;

	// Use this for initialization
	void Awake () {
		scoreText = GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
	}
}
