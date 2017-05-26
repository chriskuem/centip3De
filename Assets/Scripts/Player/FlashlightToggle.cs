using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour {

	public bool on = false;
	int playerNr;

	private Light light;

	// Use this for initialization
	void Start () {
		light = gameObject.GetComponent<Light>();
		playerNr=transform.parent.transform.parent.transform.GetSiblingIndex()+1;
		if (Gameplay.playerOneUsesKeyboard) {
			playerNr--;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//TODO: Different Player Inputs
		if(Input.GetButtonDown("Flashlight"+playerNr))
        	on = !on;
     	if(on)
        	light.enabled = true;
     	else if(!on)
        	light.enabled = false;
	}
}
