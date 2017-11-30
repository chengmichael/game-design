using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	private Text scoreText;

	public static int score;
	public static int health;

	public bool lose = false;
	// Use this for initialization
	void Awake () {
		scoreText = GetComponent<Text> ();
		score = 0;
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (score == 10) {
			scoreText.text = "You Win!";
		} else if (lose) {
			scoreText.text = "You Lose :'(";
		} else {
			scoreText.text = "Score: " + score + "    Health: " + health;
		}
	}
}
