using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomGeneration : MonoBehaviour {

	// insert Mushroom Asset
	public Transform mushroom;
	// value between 1-100
	public int spawnPercentage;
	// dimensons of the Spawn Matrix
	public Vector3 dimensons;

	private bool generated = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(!generated) generateShrooms(); generated=true;
	}

	private void generateShrooms(){
		for (int y = 0; y < dimensons.y; y++) {
        	for (int x = 0; x < dimensons.x; x++) {
				for(int z = 0; z < dimensons.z; z++){            		
					if((Random.value*100) <= spawnPercentage) Instantiate(mushroom, new Vector3(x, y, z), Quaternion.identity);
				}
        	}
    	}
	}
}
