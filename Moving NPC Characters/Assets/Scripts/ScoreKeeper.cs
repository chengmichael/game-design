using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	private Text scoreText;
	public Text winText;
	public static int score;

	// Use this for initialization
	void Awake () {
		scoreText = GetComponent<Text> ();
		score = 0;
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (score == 10) {
			winText.text = "You Win!";
		} else {
			scoreText.text = "Score: " + score;
		}
	}
}
