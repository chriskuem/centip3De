using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameInfoScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Text screenText = GetComponent<Text>();
		if (Gameplay.roundTimer == 0) {
			screenText.text = "Lvl:" + (Gameplay.lvl - 1)+Environment.NewLine + "Lifes:" + Gameplay.lives+Environment.NewLine+"Score:" + Convert.ToInt32(Gameplay.score)+"("+Gameplay.highscore+")"+Environment.NewLine + "Left:" + Gameplay.centsAlive;
		} else {
			screenText.text = "Lvl "+Gameplay.lvl+" in "+(Gameplay.roundTimer/50).ToString();
		}
	}
}
