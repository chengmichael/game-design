using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour {
	private Text scoreText;

	public static int score;
	public static int health;
	public static int targetScore;

	public bool lose = false;
	// Use this for initialization
	void Awake () {
		scoreText = GetComponent<Text> ();
		score = 0;
		health = 15;
	}
	
	// Update is called once per frame
	void Update () {
		if (score == targetScore) {
			scoreText.text = "You Win!";

			SceneManager.LoadScene ("MovingNPCScene", LoadSceneMode.Single);

		} else if (health <= 0) {
			scoreText.text = "You Lose :'(";
		} else {
			scoreText.text = "Score: " + score + "    Health: " + health;
		}
	}
}
