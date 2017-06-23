using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gameplay : MonoBehaviour {

	public static int lvl = 1;
	public static int lives = 8;
	public static float[] scores;
	public static int roundTimer;
	public static int centsAlive;
	public static bool RoundOver;
	public static int highscore;
	public static float combinedScore;
	public static int playersCount;
	public static bool playerOneUsesKeyboard;

	public Transform canvas;

	public static void Reset () {
		lvl = 1;
		lives = 8;
		scores =new float[] {0,0,0,0};
		roundTimer=500;
		centsAlive=99;
		RoundOver = true;
		playersCount=PlayerPrefs.GetInt("playercount");
		playerOneUsesKeyboard=Convert.ToBoolean(PlayerPrefs.GetInt("usekeyboard"));
		highscore=PlayerPrefs.GetInt("highscore_" + playersCount);
	}

	// Use this for initialization
	void Start () {
		Reset ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		//loose
		if (RoundOver) {

			//game over
			if (lives < 1) {

				//highscore				
				/*
				if (combinedScore > highscore) {
					highscore = Convert.ToInt32(combinedScore);
					PlayerPrefs.SetInt("highscore_" + playersCount, highscore);
				}
				
				for(int i = 0; i < scores.Length; i++){
					scores[i] = 0;
				}
				*/
				lives = 8;
				//lvl = 1;

				Cursor.lockState = CursorLockMode.None;
				canvas.gameObject.SetActive(true);
				Time.timeScale = 0;
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

