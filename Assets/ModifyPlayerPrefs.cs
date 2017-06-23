using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyPlayerPrefs : MonoBehaviour {

	public Text[] texts;

	// Use this for initialization
	public void SetPlayerCount(int playerCount) {
		PlayerPrefs.SetInt("playercount", playerCount);
	}

	public void SafeHighScore(){
		int currentScore = PlayerPrefs.GetInt("highscore_" + PlayerPrefs.GetInt("playercount"));

		string score = texts [0].text;
		float scores = float.Parse (score);
		if (currentScore < scores) {
			PlayerPrefs.SetInt ("highscore_" + PlayerPrefs.GetInt ("playercount"), Convert.ToInt32 (scores));
			PlayerPrefs.SetString ("highscore_playername_" + PlayerPrefs.GetInt ("playercount"), texts [1].text);
		}
	}

	public void LoadHighScore(){
		for (int i = 0; i < 4; i++) {
			texts[i].text = PlayerPrefs.GetString("highscore_playername_" + (i + 1)) + " - " + PlayerPrefs.GetInt("highscore_" + (i + 1));
		}
	}
}
