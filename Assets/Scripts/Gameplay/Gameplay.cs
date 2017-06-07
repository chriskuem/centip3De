using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gameplay : MonoBehaviour {

	public static int lvl=1;
	public static int lives=8;
	public static float[] scores = {0,0,0,0};
	public static int roundTimer=500;
	public static int centsAlive=99;
	public static bool RoundOver = true;
	public static int highscore;
	public static float combinedScore;
	public static int playersCount;
	public static bool playerOneUsesKeyboard;

	// Use this for initialization
	void Start () {
		highscore=PlayerPrefs.GetInt("highscore_" + playersCount);
	}

	// Update is called once per frame
	void FixedUpdate () {

		//loose
		if (RoundOver) {

			//game over
			if (lives < 1) {

				//highscore				
				if (combinedScore > highscore) {
					highscore = Convert.ToInt32(combinedScore);
					PlayerPrefs.SetInt("highscore_" + playersCount, highscore);
				}
				
				for(int i = 0; i < scores.Length; i++){
					scores[i] = 0;
				}
				lives = 8;
				lvl = 1;
			}

			if (roundTimer == 0) {
				roundTimer = 500;
			} else {
				roundTimer--;
			}
			if (roundTimer == 0) {
				RoundOver = false;
			}
		} else {
			//score
			for(int i = 0; i < playersCount; i++){
					scores[i] += 0.008f;
			}
			combinedScore = scores[0] + scores[1] + scores[2] + scores[3];
		}
		}
	}

