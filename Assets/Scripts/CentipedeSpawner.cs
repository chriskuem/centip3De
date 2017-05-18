﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeSpawner : MonoBehaviour {

	public GameObject CentipedePrefab;
	public int centipedeCount=1;
	public float playfieldHeight = 100f;

	// Use this for initialization
	void Start () {

		//Create all centipedes
		for (int i = 0; i < centipedeCount; i++) {

			// Create the centipedes from the centipede Prefab
			var centipede = (GameObject)Instantiate(
				CentipedePrefab,
				new Vector3(0f+(i*2f),playfieldHeight,0f),
				transform.rotation);

			centipede.transform.parent=gameObject.transform;

		}
	}

	// Update is called once per frame
	void Update () {

	}
}
