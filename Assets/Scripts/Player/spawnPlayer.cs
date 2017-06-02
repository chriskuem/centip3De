using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spawnPlayer : MonoBehaviour {

	public GameObject PlayerPrefab;
	public int playerCount=1;
	public bool PlayerOneUsesKeyboard = true;
	public Texture2D crosshairImage;

	// Use this for initialization
	void Start () {

		//read startparameter------------------------------
		string[] args = Environment.GetCommandLineArgs();
		foreach(string argument in args){

		int number;
		bool result = Int32.TryParse(argument, out number);
			if (result) {
				if (number != 0 && number <= 4) {
					playerCount = number;
				}
			}
		}
		//--------------------------------------------------

		Gameplay.playerOneUsesKeyboard = PlayerOneUsesKeyboard;

		//Limit to 4 players
		if(playerCount>4){
			playerCount=4;
		}
		Gameplay.playersCount = playerCount;

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

	void OnGUI(){
		float xMin;
		float yMin;
		switch (playerCount){
			case 1:
				xMin = (Screen.width / 2) - (crosshairImage.width / 2);
				yMin = (Screen.height / 2) - (crosshairImage.height / 2);
				GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage, ScaleMode.ScaleToFit);
				break;
			case 2:
				xMin = ((Screen.width / 2) - (crosshairImage.width / 2)) /2;
				yMin = (Screen.height / 2) - (crosshairImage.height / 2);
				GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width/2, crosshairImage.height), crosshairImage, ScaleMode.ScaleToFit);
				GUI.DrawTexture(new Rect((Screen.width/2)+xMin, yMin, crosshairImage.width/2, crosshairImage.height), crosshairImage, ScaleMode.ScaleToFit);
				break;
			case 3:
				xMin = ((Screen.width / 2) - (crosshairImage.width / 2)) / 2;
				yMin = ((Screen.height / 2) - (crosshairImage.height / 2)) / 2;
				GUI.DrawTexture(new Rect(xMin*2, yMin, crosshairImage.width, crosshairImage.height/2), crosshairImage, ScaleMode.ScaleToFit);
				GUI.DrawTexture(new Rect(xMin,(Screen.height/2)+yMin, crosshairImage.width/2, crosshairImage.height/2), crosshairImage, ScaleMode.ScaleToFit);
				GUI.DrawTexture(new Rect((Screen.width/2)+xMin,(Screen.height/2)+yMin, crosshairImage.width/2, crosshairImage.height/2), crosshairImage, ScaleMode.ScaleToFit);
				break;
			case 4:
				xMin = ((Screen.width / 2) - (crosshairImage.width / 2)) / 2;
				yMin = ((Screen.height / 2) - (crosshairImage.height / 2)) / 2;
				GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width/2, crosshairImage.height/2), crosshairImage, ScaleMode.ScaleToFit);
				GUI.DrawTexture(new Rect(xMin, (Screen.height/2)+yMin, crosshairImage.width/2, crosshairImage.height/2), crosshairImage, ScaleMode.ScaleToFit);
				GUI.DrawTexture(new Rect((Screen.width/2)+xMin, yMin, crosshairImage.width/2, crosshairImage.height /2), crosshairImage, ScaleMode.ScaleToFit);
				GUI.DrawTexture(new Rect((Screen.width/2)+xMin, (Screen.height/2)+yMin, crosshairImage.width/2, crosshairImage.height/2), crosshairImage, ScaleMode.ScaleToFit);
				break;
		}
	}
}
