﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour {

	Text text;
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = Gameplay.combinedScore.ToString();
	}
}
