using System.Collections;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(600,200);
	public Texture2D emptyTex;
	public Texture2D fullTex;

	void OnGUI() {
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);

		GUI.EndGroup();
		GUI.EndGroup();
	}
	void Start() {
		barDisplay = 1.0f;
	}
	void Update() {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.
		//barDisplay = 0.5f;//Time.time*0.05f;
		//        barDisplay = MyControlScript.staticHealth;
		if (barDisplay < 0f) {
			GameObject.Find("Score").GetComponent<ScoreKeeper>().lose = true;
		}
	}
}

