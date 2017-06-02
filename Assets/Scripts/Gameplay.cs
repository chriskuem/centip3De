using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gameplay : MonoBehaviour {

	public static int lvl=1;
	public static int lives=8;
	public static float score=0;
	public static int roundTimer=500;
	public static int centsAlive=99;
	public static bool RoundOver = true;
	public static int highscore;
	public static int playersCount;
	public static bool playerOneUsesKeyboard;

	// Use this for initialization
	void Start () {
		highscore=PlayerPrefs.GetInt("highscore");
	}

	// Update is called once per frame
	void FixedUpdate () {

		//loose
		if (RoundOver) {

			//game over
			if (lives < 1) {

				//highscore
				if (Convert.ToInt32 (score) > highscore) {
					highscore = Convert.ToInt32 (score);
					PlayerPrefs.SetInt("highscore",highscore);
					}

				score = 0;
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
			score=score+0.008f;
		}
		}
	}

