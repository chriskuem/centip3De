using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour {

	//Movement
	public float speed=1;
	public float jumpheight=75;

	//Mouse look around
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity=5;
	public float smoothing=2;

	// Use this for initialization
	void Start () {
		//Lock Mouse in Window
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

		//movement-------------------------
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate (straffe, 0, translation);
		//---------------------------------

		//look around----------
		var cam = transform.GetChild(0);
		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1 / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1 / smoothing);
		mouseLook += smoothV;

		//Sicht beschränken
		mouseLook.y=Mathf.Clamp(mouseLook.y,-90f,120f);

		cam.transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		transform.localRotation = Quaternion.AngleAxis (mouseLook.x, transform.up);
		//------------------------

		//jump----------------
		if (Input.GetButtonDown ("Jump")){
			this.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpheight * Time.deltaTime, 0);
			        } 
		//----------------------

		//unlock mouse
		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;

	}
}
