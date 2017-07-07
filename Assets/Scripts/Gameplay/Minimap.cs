using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Minimap : MonoBehaviour {


	float ratio;
	int count;

	// Use this for initialization
	void Start () {
		SetupMinimap ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (ratio != 100f * Screen.height / Screen.width || count != Gameplay.playersCount) {
			SetupMinimap ();
		}
	}

	void SetupMinimap(){
		Camera cam = transform.gameObject.GetComponent<Camera> ();
		ratio = 100f*Screen.height / Screen.width;

		float heightCam = 0.25f;
		float widthCam = (heightCam * ratio)/100f;

		//place minimap into center if 4 players
		count=Gameplay.playersCount;
		if (count > 2 ) {
			cam.rect = new Rect (0.5f-(widthCam/2f), 0.5f - (heightCam/2), widthCam, heightCam);
		} 
		else if(count == 2){
			cam.rect = new Rect (0.5f-(widthCam/2f), 0f, widthCam, heightCam);
		}
		else {
			cam.rect = new Rect (0f, 1f - heightCam, widthCam, heightCam);
		}
	}
}
