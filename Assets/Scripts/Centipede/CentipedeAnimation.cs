using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeAnimation : MonoBehaviour {

	public float speed = 2f;
    public float maxRotation = 45f;

	public char axis = 'x';

	private Quaternion curRotation = Quaternion.identity;

	// Use this for initialization
	void Start () {		
		curRotation = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (axis == 'x') transform.rotation = Quaternion.Euler(curRotation.eulerAngles.x - (maxRotation * Mathf.Sin(Time.time * speed)), curRotation.eulerAngles.y, curRotation.eulerAngles.z);
		else if (axis == 'y') transform.rotation = Quaternion.Euler(curRotation.eulerAngles.x, curRotation.eulerAngles.y - (maxRotation * Mathf.Sin(Time.time * speed)), curRotation.eulerAngles.z);
		else if (axis == 'z') transform.rotation = Quaternion.Euler(curRotation.eulerAngles.x, curRotation.eulerAngles.y, curRotation.eulerAngles.z - (maxRotation * Mathf.Sin(Time.time * speed)));
	}
}
