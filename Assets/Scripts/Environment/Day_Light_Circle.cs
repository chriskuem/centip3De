using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Light_Circle : MonoBehaviour {

	bool direction=true;
	float light=0.5f;
	float steps=0.0005f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (direction) {
			light = light + steps;
		} else {
			light = light - steps;
		}
		if (light < 0.5f) {
			direction = true;
		}
		//Feature vorerst wieder herausgenommen (ansonsten z.B. 1.3f)
		if (light > 0.5f) {
			direction = false;
		}

		gameObject.GetComponent<Light> ().intensity = light;
	}
}
