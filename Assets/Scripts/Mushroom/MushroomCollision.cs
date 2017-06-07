using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCollision : MonoBehaviour {

	public Transform mushroomFull;
	public Transform mushroomMiddle;
	public Transform mushroomLow;
	public Transform leftovers;

	private int hitCount = 0;
	private Transform trans;
	private Vector3 initVec;
	// Use this for initialization
	void Start () {
		initVec = gameObject.transform.position;
		initVec.y = initVec.y - 0.5f;
		Transform test = Instantiate(mushroomFull, initVec, Quaternion.Euler(270, 0, 0));
		test.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
		if (col.collider.name == "Bullet_0" || col.collider.name == "Bullet_1" ||col.collider.name == "Bullet_2" || col.collider.name == "Bullet_3") {
			if (hitCount == 0) {
				Destroy (gameObject.transform.GetChild (0).transform.gameObject, 0.1f);
				trans = Instantiate (mushroomMiddle, initVec, Quaternion.Euler (270, 0, 0));
				trans.transform.parent = gameObject.transform;
			}
			if (hitCount == 1) {
				Destroy (gameObject.transform.GetChild (0).transform.gameObject, 0.3f);
				trans = Instantiate (mushroomLow, initVec, Quaternion.Euler (270, 0, 0));
				trans.transform.parent = gameObject.transform;
			}
			if (hitCount == 2) {
				trans = Instantiate (leftovers, initVec, Quaternion.identity);
				Destroy (trans.gameObject, 100f);
				Destroy (gameObject);

				if (col.collider.name == "Bullet_0")Gameplay.scores[0]++;
				if (col.collider.name == "Bullet_1")Gameplay.scores[1]++;
				if (col.collider.name == "Bullet_2")Gameplay.scores[2]++;
				if (col.collider.name == "Bullet_3")Gameplay.scores[3]++;
			}
			hitCount++;
		}
	}
}
