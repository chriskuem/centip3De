using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	public Transform puSlow;
	public Transform pu3Shots;
	public Transform puDubstep;

	public GameObject disco;

	public int typeInt = 0;
	string type;

	// Use this for initialization
	void Start () {
		//wenn kein Typ vordefiniert
		if (typeInt == 0) {
			//random type
			int percentage = System.Convert.ToInt32(Random.value*100) + 1;

			if (percentage < 40) {
				typeInt = 1;
			} else if (percentage >= 40 && percentage < 90) {
				typeInt = 2;
			} else {
				typeInt = 3;
			}
		}

		Transform usedTransform;
		if (typeInt == 1) {
			type = "Slow";
			usedTransform = puSlow;
		} else if (typeInt == 2) {
			type = "Dreifachschuss";
			usedTransform = pu3Shots;
		} else {
			type = "Dubstep Canon";
			usedTransform = puDubstep;
		}

		var powerUpObject = Instantiate (usedTransform, transform.position + usedTransform.position, (transform.rotation * usedTransform.transform.localRotation));
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

				if (type == "Slow") {
					Time.timeScale = 0.5f;
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().powerUpTimeLeft = 300;
				}
				else if (type == "Dreifachschuss") {
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().reloadTime = 0.200f;
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().bulletspeed = 50f;
				}
				else if (type == "Dubstep Canon") {
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().reloadTime = 0.050f;
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().bulletspeed = 20f;
					col.collider.transform.Find ("MovingParts").transform.Find ("Weapon").transform.GetComponent<weapon> ().powerUpTimeLeft = 500;


					GameObject discoTransform = (GameObject)Instantiate (disco, disco.transform.position, disco.transform.rotation);
					Destroy (discoTransform, 10.0f);    

					MusicVolume.PauseMusicFor (10.0f);

					DubstepSoundObject.audio.volume = PlayerPrefs.GetFloat("music_vol")*2f;
					DubstepSoundObject.audio.Play ();
				}

				PickupSoundObject.audio.Play();

			}

			Destroy (this.gameObject);
		}
	}
}
