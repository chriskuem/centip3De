﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

	public GameObject[] bulletPrefab;
	public float bulletspeed=6f;
	int playerNr;
	bool keepFiring=false;
	float reloadTime=0.100f;
	float lastShot=0f;

	private GameObject bullet;

	// Use this for initialization
	void Start () {
		playerNr=this.transform.parent.transform.parent.transform.GetSiblingIndex()+1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {




		if (Input.GetButton ("Fire" + playerNr)) {
			
			keepFiring = true;
		} 
		else {
			keepFiring = false;
		}

		if (keepFiring) {
			Fire ();
		}
	}

	void Fire()
	{
		float currentTime = Time.time;
		if (currentTime - reloadTime > lastShot) {

			//audio
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play ();

			//spawn at BulletSpawn location with direction of BulletSpawn(camera)
			Transform bulletSpawn = this.transform.parent.transform.Find ("BulletSpawn").gameObject.transform;

			// Create the Bullet from the Bullet Prefab
			switch(transform.parent.transform.parent.transform.GetSiblingIndex()){
				case 0:
					bullet = (GameObject)Instantiate(bulletPrefab[0], bulletSpawn.position, bulletSpawn.rotation);
					break;
				case 1:
					bullet = (GameObject)Instantiate(bulletPrefab[1], bulletSpawn.position, bulletSpawn.rotation);
					break;
				case 2: 
					bullet = (GameObject)Instantiate(bulletPrefab[2], bulletSpawn.position, bulletSpawn.rotation);
					break;
				case 3:
					bullet = (GameObject)Instantiate(bulletPrefab[3], bulletSpawn.position, bulletSpawn.rotation);
					break;
			}

			Physics.IgnoreCollision(transform.parent.transform.parent.transform.gameObject.GetComponent<Collider>(), bullet.GetComponent<Collider>());
			// Add velocity to the bullet
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletspeed;
			bullet.name="Bullet";

			// Add velocity to the bullet
			bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * bulletspeed;
			bullet.name = "Bullet";

			// Destroy the bullet after 20 seconds
			Destroy (bullet, 20.0f);        
		
			lastShot = currentTime;
		}
	}
}
