using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Powerup : MonoBehaviour {

	public Transform puSniper;
	public Transform pu3Shots;
	public Transform puDubstep;

	public int typeInt = 0;
	string type;

	// Use this for initialization
	void Start () {
		
		//wenn kein Typ vordefiniert
		if (typeInt == 0) {
			//random type
			System.Random rnd = new System.Random ();
			typeInt = rnd.Next (1, 4);
		}

		Transform usedTransform;
		if (typeInt == 1) {
			type = "Sniper";
			usedTransform = puSniper;
		} else if (typeInt == 2) {
			type = "Dreifachschuss";
			usedTransform = pu3Shots;
		} else {
			type = "Dubstep Canon";
			usedTransform = puDubstep;
		}

		var powerUpObject = Instantiate (usedTransform, transform.position, (transform.rotation * usedTransform.transform.localRotation));
		powerUpObject.transform.parent=gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){

		if (col.collider.name == "Player_0" || col.collider.name == "Player_1" || col.collider.name == "Player_2" || col.collider.name == "Player_3") {

			if (col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> () != null) {
			
				col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().powerUpactive = typeInt;
				col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().powerUpTimeLeft = 1000;

				if (type == "Sniper") {
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().reloadTime = 0.400f;
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().bulletspeed = 50f;
				}
				else if (type == "Dreifachschuss") {
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().reloadTime = 0.200f;
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().bulletspeed = 5f;
				}
				else if (type == "Dubstep Canon") {
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().reloadTime = 0.100f;
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().bulletspeed = 6f;
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().powerUpTimeLeft = 500;

					DubstepSoundObject.audio.Play ();
				}

				AudioSource audio = this.transform.gameObject.GetComponent<AudioSource>();
				audio.Play();

			}

			Destroy (this.gameObject);
		}
	}
}
