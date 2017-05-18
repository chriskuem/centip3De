using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeMovement : MonoBehaviour {

	int partNr;
	public float currentHeight = 50;
	public Vector3 target;
	public float speed = 1f;
	int direction=0;
	int directionBefore=0;

	// Use this for initialization
	void Start () {
		partNr=transform.GetSiblingIndex();
		currentHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//head
		if (partNr == 0) {
			//Ebene tiefer
			if (transform.position.y > currentHeight) {
				target = new Vector3 (transform.position.x, currentHeight-0.5f, transform.position.z);
				direction = 0;
			} else if(direction==0) {
				//4 random directions
				System.Random random = new System.Random();
				while (direction==directionBefore)direction = random.Next(1, 5);
				if(direction==1)target = new Vector3 (100, transform.position.y, transform.position.z);
				if(direction==2)target = new Vector3 (-100, transform.position.y, transform.position.z);
				if(direction==3)target = new Vector3 (transform.position.z, transform.position.y, 100);
				if(direction==4)target = new Vector3 (transform.position.z, transform.position.y, -100);
				directionBefore = direction;
			}

			//dir to target
			var dir = target-transform.position;

			//Rotate towards part ahead and move
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime*speed);
			transform.position += transform.forward * Time.deltaTime*speed;

		}

		//non-head
		else {
			//part ahead
			GameObject ahead =transform.parent.transform.GetChild(partNr-1).gameObject;

			//dir to part ahead
			var dir = ahead.transform.position - transform.position;

			//if distance to high
			if(dir.magnitude > 1.0f)
			{
				//Rotate towards part ahead and move
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), dir.magnitude * Time.deltaTime*speed);
				transform.position += transform.forward * dir.magnitude * Time.deltaTime*speed;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		currentHeight--;
	}
}
