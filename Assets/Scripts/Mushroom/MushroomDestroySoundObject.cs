using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomDestroySoundObject : MonoBehaviour {

	public static AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
