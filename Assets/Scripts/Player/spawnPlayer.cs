using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spawnPlayer : MonoBehaviour {

	public GameObject PlayerPrefab;
	public int playerCount=1;

	// Use this for initialization
	void Start () {

		//Limit to 4 players
		if(playerCount>4){
			playerCount=4;
		}

		//Create all players
		for (int i = 0; i < playerCount; i++) {
		
			// Create the player from the player Prefab
		var player = (GameObject)Instantiate(
			PlayerPrefab,
			new Vector3(0f+(i*2f),3f,0f),
			transform.rotation);

			player.transform.parent=gameObject.transform;

			//Setup cameras
			Camera cam = player.transform.Find("MovingParts").gameObject.transform.Find("FPSCamera").gameObject.GetComponent<Camera> ();

			if (playerCount > 2) {
				float height = 0.5f;
				float ypos;
				float xpos;
				float width;

				if((i+1)<=Math.Floor (playerCount/2f)){
					ypos = 0.5f;
					width = Convert.ToSingle(1f/(Math.Floor (playerCount / 2f)));
					xpos = width * i;
				}
				else{
					ypos = 0f;
					width = Convert.ToSingle(1f/(playerCount-(Math.Floor (playerCount / 2f))));
					xpos = 1-((playerCount-i)*width) ;
				}


				cam.rect = new Rect (xpos, ypos, width, height);

				//place minimap into center
				if (playerCount == 4) {
					transform.parent.Find ("MapCam").gameObject.GetComponent<Camera> ().rect = new Rect (0.445f, 0.4f, 0.11f, 0.2f);
				}

			} else {
				cam.rect = new Rect ((1f/playerCount)*i, 0, (1f/playerCount), 1);
			}



		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
