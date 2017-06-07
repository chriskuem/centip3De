using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeSpawnParts : MonoBehaviour {

	public GameObject CentipedePartPrefab;
	public int centipedePartCount=10;

	//CentipedeMovement Parameters
	public float speed;
	public float playfieldSize;
	public Transform head;
	public Transform body;

	// Use this for initialization
	void Start () {

		//get params from parent-------------------------------------
		//CentipedeSpawnParts Parameters
		CentipedePartPrefab=this.transform.parent.GetComponent<CentipedeSpawner>().CentipedePartPrefab;
		centipedePartCount=this.transform.parent.GetComponent<CentipedeSpawner>().centipedePartCount;

		//CentipedeMovement Parameters
		speed=this.transform.parent.GetComponent<CentipedeSpawner>().speed;
		playfieldSize=this.transform.parent.GetComponent<CentipedeSpawner>().playfieldSize;
		head=this.transform.parent.GetComponent<CentipedeSpawner>().head;
		body=this.transform.parent.GetComponent<CentipedeSpawner>().body;
		//-------------------------------------------------------------------


		//Create all centipedes
		for (int i = 0; i < centipedePartCount+Gameplay.lvl-1; i++) {

			// Create the centipedes from the centipede Prefab
			var centipedePart = (GameObject)Instantiate(
				CentipedePartPrefab,
				transform.position+new Vector3(0f+(i),0f,0f),
				transform.rotation);

			centipedePart.transform.parent=gameObject.transform;
			centipedePart.name = "Part" + i;

		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//dont use, doesnt influence newly created cents
	}
}
