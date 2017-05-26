using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeSpawner : MonoBehaviour {

	public GameObject CentipedePrefab;
	public int centipedeCount=1;
	public float playfieldHeight = 100f;

	int lastTimeAlive=99;

	// Use this for initialization
	void Start () {


	}

	void FixedUpdate () {

		Gameplay.centsAlive=transform.childCount;

		if (Gameplay.centsAlive == 0 && Gameplay.centsAlive != lastTimeAlive) {
			Gameplay.RoundOver = true;
		} else {
		
			if (Gameplay.centsAlive == 0 && Gameplay.roundTimer == 0) {
				//Create all centipedes
				for (int i = 0; i < centipedeCount*Gameplay.playersCount; i++) {

					// Create the centipedes from the centipede Prefab
					var centipede = (GameObject)Instantiate (
						               CentipedePrefab,
						               new Vector3 (0f, playfieldHeight, 0f + (i * 2f)),
						               transform.rotation);

					centipede.transform.parent = gameObject.transform;
				}
				Gameplay.lvl++;
				Gameplay.lives++;
				Gameplay.lives++;
			}
		//delete empty centipedes if more than 0 childs
		else {
				foreach (Transform child in transform) {
					if (child.childCount == 0) {
						GameObject.Destroy (child.gameObject);
					}
				}
			}
		}
		lastTimeAlive = Gameplay.centsAlive;
	}
}
