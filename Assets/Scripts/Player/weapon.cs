using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

	public GameObject bulletPrefab;
	public float bulletspeed=6f;
	int playerNr;

	// Use this for initialization
	void Start () {
		playerNr=this.transform.parent.transform.parent.transform.GetSiblingIndex()+1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire"+playerNr))
		{
			Fire();
		}
	}

	void Fire()
	{
		//spawn at BulletSpawn location with direction of BulletSpawn(camera)
		Transform bulletSpawn =this.transform.parent.transform.Find("BulletSpawn").gameObject.transform;

		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		Physics.IgnoreCollision(transform.parent.transform.parent.transform.gameObject.GetComponent<Collider>(), bullet.GetComponent<Collider>());
		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletspeed;
		bullet.name="Bullet";

		// Destroy the bullet after 20 seconds
		Destroy(bullet, 20.0f);        
	}
}
