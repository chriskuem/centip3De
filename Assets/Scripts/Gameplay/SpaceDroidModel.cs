using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDroidModel : MonoBehaviour {

	public Texture2D[] textures;
	public ParticleSystem[] particleSystems;

	private ParticleSystem particleSystem;

	// Use this for initialization
	void Start () {
		if (textures.Length != 4 || textures == null) return;

		
		Renderer renderer = GetComponent<Renderer> ();
		switch(transform.parent.transform.parent.transform.parent.transform.GetSiblingIndex()){
			case 0:
				renderer.material.mainTexture = textures[0];
				particleSystem = Instantiate(particleSystems[0],gameObject.transform.position,particleSystems[0].transform.localRotation);
				particleSystem.transform.parent = gameObject.transform.parent.transform;
				break;
			case 1:
				renderer.material.mainTexture = textures[1];
				particleSystem = Instantiate(particleSystems[1],gameObject.transform.position,particleSystems[1].transform.localRotation);
				particleSystem.transform.parent = gameObject.transform.parent.transform;
				break;
			case 2: 
				renderer.material.mainTexture = textures[2];
				particleSystem = Instantiate(particleSystems[2],gameObject.transform.position,particleSystems[2].transform.localRotation);
				particleSystem.transform.parent = gameObject.transform.parent.transform;
				break;
			case 3:
				renderer.material.mainTexture = textures[3];
				particleSystem = Instantiate(particleSystems[3],gameObject.transform.position,particleSystems[3].transform.localRotation);
				particleSystem.transform.parent = gameObject.transform.parent.transform;
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
