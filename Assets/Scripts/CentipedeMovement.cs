using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeMovement : MonoBehaviour {

	int partNr;

	// Use this for initialization
	void Start () {
		partNr=transform.GetSiblingIndex();
		if (partNr == 0) {
			transform.GetComponent<Rigidbody> ().velocity = transform.forward * 10f;
		} else {
			transform.gameObject.AddComponent<ConfigurableJoint>().connectedBody=transform.parent.transform.GetChild(partNr-1).gameObject.transform.GetComponent<Rigidbody> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (partNr == 0) {
			transform.GetComponent<Rigidbody> ().velocity = transform.forward * 10f;
		}
	}
}
