using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomGeneration : MonoBehaviour {

	// insert Mushroom Asset
	public Transform mushroom;
	public static Transform mushroomPublic;
	// value between 1-100
	public int spawnPercentage;
	// dimensons of the Spawn Matrix
	public Vector3 matrixDimensons;
	// offset for Matrix Startingposition
	public Vector3 matrixOffset;
	// spawntime for Shrooms
	public float spawnTime;

	// Use this for initialization
	void Start () {
		StartCoroutine(generateShrooms(spawnTime));
		mushroomPublic = mushroom;
	}
	
	// Update is called once per frame
	void Update () {
	}

	private IEnumerator generateShrooms(float spawnTime){
		for (float y = matrixDimensons.y; y > 0; y--) {
        	for (int x = 0; x < matrixDimensons.x; x++) {
				for(int z = 0; z < matrixDimensons.z; z++){    
					if((Random.value*100) <= spawnPercentage) {
						Instantiate(mushroom, (new Vector3(x,y,z) + matrixOffset), Quaternion.identity);	
					}
				}
        	}
			yield return new WaitForSeconds(spawnTime); 
    	}
	}
}
