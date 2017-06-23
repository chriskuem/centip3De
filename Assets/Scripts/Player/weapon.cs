using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class weapon : MonoBehaviour {

	public GameObject[] bulletPrefab;
	public float bulletspeed=50f;
	int playerNr;
	bool keepFiring=false;
	public float reloadTime=0.200f;
	float lastShot=0f;

	public int powerUpTimeLeft=0;
	public int powerUpactive=0;

	private GameObject bullet;

	// Use this for initialization
	void Start () {
		playerNr=this.transform.parent.transform.parent.transform.GetSiblingIndex()+1;
		if (Gameplay.playerOneUsesKeyboard) {
			playerNr--;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		int PowerUp = PowerUpCurrentlyActive ();

		if (Input.GetButton ("Fire" + playerNr)) {
			
			keepFiring = true;
		} else {
			keepFiring = false;
		}

		if(PowerUp==3)
			keepFiring = true;

		if (keepFiring) {
			bool ShotFired = Fire (PowerUp == 3,!(PowerUp == 3),false);
			if ((PowerUp == 2 || PowerUp == 3)&&ShotFired) {
				Fire (PowerUp == 3,!(PowerUp == 3),true);
				Fire (PowerUp == 3,!(PowerUp == 3),true);
			}
		}

		if (PowerUp > 0) {
			powerUpTimeLeft--;
		}
		else{
			reloadTime = 0.200f;
			bulletspeed = 50f;
			Time.timeScale = 1f;
		}

	
	}

	int PowerUpCurrentlyActive(){
		if (powerUpTimeLeft > 0) {

			if (powerUpactive == 1)
				return 1;
			else if (powerUpactive == 2)
				return 2;
			else if (powerUpactive == 3)
				return 3;
			else
				return 0;

		} else
			return 0;
	}

	bool Fire(bool RandomColor,bool Straight, bool IgnoreReloadTime)
	{
		float currentTime = Time.time;
		if (currentTime - reloadTime > lastShot || IgnoreReloadTime) {

			//audio
			BulletSoundObject.audio.Play ();

			//spawn at BulletSpawn location with direction of BulletSpawn(camera)
			Transform bulletSpawn = this.transform.parent.transform.Find ("BulletSpawn").gameObject.transform;


			if (RandomColor) {
				System.Random rnd = new System.Random ();
				int colorNr = rnd.Next (0, 4);
				bullet = (GameObject)Instantiate (bulletPrefab [colorNr], bulletSpawn.position, bulletSpawn.rotation);
			}

			// Create the Bullet from the Bullet Prefab
			switch (transform.parent.transform.parent.transform.GetSiblingIndex ()) {
			case 0:
				if (!RandomColor)
					bullet = (GameObject)Instantiate (bulletPrefab [0], bulletSpawn.position, bulletSpawn.rotation);
				bullet.name = "Bullet_0";
				break;
			case 1:
				if (!RandomColor)
					bullet = (GameObject)Instantiate (bulletPrefab [1], bulletSpawn.position, bulletSpawn.rotation);
				bullet.name = "Bullet_1";
				break;
			case 2: 
				if (!RandomColor)
					bullet = (GameObject)Instantiate (bulletPrefab [2], bulletSpawn.position, bulletSpawn.rotation);
				bullet.name = "Bullet_2";
				break;
			case 3:
				if (!RandomColor) 
					bullet = (GameObject)Instantiate (bulletPrefab [3], bulletSpawn.position, bulletSpawn.rotation);
				bullet.name = "Bullet_3";
				break;
			}
		
				

			Physics.IgnoreCollision(transform.parent.transform.parent.transform.gameObject.GetComponent<Collider>(), bullet.GetComponent<Collider>());
			// Add velocity to the bullet
			if (Straight)
				bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * bulletspeed;
			else {
				//add random vector to direction
				System.Random rnd = new System.Random ();
				int x = rnd.Next (-30, 30);
				int z = rnd.Next (-30, 30);
				bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * bulletspeed + 0.2f*(new Vector3 (x, 30f, z));
			}
			bullet.transform.parent = TempContainer.tempCont.transform;

			// Destroy the bullet after 20 seconds
			Destroy (bullet, 20.0f);     

			lastShot = currentTime;

			return true;
		}
		else return false;
	}
}
