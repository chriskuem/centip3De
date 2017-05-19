using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//transform.parent=transform.parent.transform.Find("_Temp").gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
			Object.Destroy(this.gameObject);
	}
}
