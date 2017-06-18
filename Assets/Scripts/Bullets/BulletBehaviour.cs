using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name != "Bullet_0" && collision.collider.name != "Bullet_1" && collision.collider.name != "Bullet_2" && collision.collider.name != "Bullet_3") {
			Object.Destroy (this.gameObject);
		}
	}
}
