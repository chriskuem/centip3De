using System.Collections;
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
				new Vector3(0f,playfieldHeight,0f+(i*2f)),
				transform.rotation);

			centipede.transform.parent=gameObject.transform;

		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//delete empty centipedes if more than 3 childs
		if (transform.childCount > 3) {
			foreach (Transform child in transform) {
				if (child.childCount == 0) {
					GameObject.Destroy (child.gameObject);
				}
			}
		}
	}
}
