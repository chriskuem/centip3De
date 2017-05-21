using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeAnimation : MonoBehaviour {

	public float speed = 2f;
    public float maxRotation = 45f;

	public char axis = 'x';

	private Quaternion curRotation = Quaternion.identity;
	private Quaternion startRotation = Quaternion.identity;

	// Use this for initialization
	void Start () {
		curRotation = gameObject.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		int rotDir = transform.parent.transform.GetSiblingIndex () % 2 == 0 ? -1 : 1;

		if (axis == 'x') transform.localRotation = Quaternion.Euler(curRotation.eulerAngles.x - (maxRotation * Mathf.Sin(Time.time * speed * rotDir)), curRotation.eulerAngles.y, curRotation.eulerAngles.z);
		else if (axis == 'y') transform.localRotation = Quaternion.Euler(curRotation.eulerAngles.x, curRotation.eulerAngles.y - (maxRotation * Mathf.Sin(Time.time * speed * rotDir)), curRotation.eulerAngles.z);
		else if (axis == 'z') transform.localRotation = Quaternion.Euler(curRotation.eulerAngles.x, curRotation.eulerAngles.y, curRotation.eulerAngles.z - (maxRotation * Mathf.Sin(Time.time * speed * rotDir)));
	}
}
