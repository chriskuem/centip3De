using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour {

	//Movement
	public float speed=1;
	public float jumpheight=75;
	int playerNr;

	//Mouse look around
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity=5;
	public float smoothing=2;

	//name of container with moving parts
	public string NameOfMovingPartsContainer="MovingParts";

	// Use this for initialization
	void Start () {
		playerNr=transform.GetSiblingIndex()+1;

		//Lock Mouse in Window
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

		//movement-------------------------
		if(Input.GetKeyDown(KeyCode.LeftShift))speed=speed*3;
		if(Input.GetKeyUp(KeyCode.LeftShift))speed=speed/3;
		float translation = Input.GetAxis ("Vertical"+playerNr) * speed;
		float straffe = Input.GetAxis ("Horizontal"+playerNr) * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate (straffe, 0, translation);
		//---------------------------------

		//look around----------
		var cam = transform.Find(NameOfMovingPartsContainer).gameObject;
		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"+playerNr), Input.GetAxisRaw ("Mouse Y"+playerNr));

		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1 / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1 / smoothing);
		mouseLook += smoothV;

		//Sicht beschränken
		mouseLook.y=Mathf.Clamp(mouseLook.y,-80f,120f);

		cam.transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		transform.localRotation = Quaternion.AngleAxis (mouseLook.x, transform.up);
		//------------------------

		//jump----------------
		if (Input.GetButtonDown ("Jump"+playerNr)&&transform.position.y<1){
			this.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpheight * Time.deltaTime, 0);
			        } 
		//----------------------

		//unlock mouse
		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;

	}
}
