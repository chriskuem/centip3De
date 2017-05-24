using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour {

	public bool on = false;

	private Light light;

	// Use this for initialization
	void Start () {
		light = gameObject.GetComponent<Light>();
		
	}
	
	// Update is called once per frame
	void Update () {
		//TODO: Different Player Inputs
		if(Input.GetKeyDown(KeyCode.F))
        	on = !on;
     	if(on)
        	light.enabled = true;
     	else if(!on)
        	light.enabled = false;
	}
}
