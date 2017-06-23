using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CentipedeMovement : MonoBehaviour {

	int partNr;
	float currentHeight;
	Vector3 target=new Vector3(0f,0f,0f);

	public float speed;
	public float playfieldSize;

	int direction=0;
	int directionBefore=0;

	public Transform head;
	public Transform body;

	//spotlight on ground
	GameObject lightGameObject;

	// Use this for initialization
	void Start () {

		//get params from parent-------------------------------------
		//CentipedeMovement Parameters
		if(this.transform.parent.GetComponent<CentipedeSpawnParts>()!=null){
		speed=this.transform.parent.GetComponent<CentipedeSpawnParts>().speed;
		playfieldSize=this.transform.parent.GetComponent<CentipedeSpawnParts>().playfieldSize;
		head=this.transform.parent.GetComponent<CentipedeSpawnParts>().head;
		body=this.transform.parent.GetComponent<CentipedeSpawnParts>().body;
		}
		//-------------------------------------------------------------------

		speed = speed + (Gameplay.lvl-1f)/3;
		playfieldSize = playfieldSize / 2;
		partNr=999;


		var bodyObject=Instantiate(body,transform.position,(transform.rotation * body.transform.localRotation));
		bodyObject.transform.parent=gameObject.transform;
	}

	void IndexChanged(int newIndex){
		currentHeight = transform.position.y;

		//change mesh for head
		if (newIndex == 0) {
			var headObject=Instantiate(head,transform.position,(transform.rotation * head.transform.localRotation));
			headObject.transform.parent=gameObject.transform;

			//remove old prefab
			if (transform.childCount > 0) {
				UnityEngine.Object.Destroy (transform.GetChild(0).gameObject);
			}

			// Create spotlight
			/*
			lightGameObject = new GameObject("Spotlight");
			Light lightSpot = lightGameObject.AddComponent<Light>();
			lightSpot.type = LightType.Spot;
			//lightSpot.range = 300;
			lightSpot.spotAngle = 10;
			lightSpot.intensity = 4;
			lightSpot.shadows = LightShadows.Soft;

			lightGameObject.transform.parent=gameObject.transform;
			*/



		} else {
			//ignore collisions within centipede
			Physics.IgnoreCollision(transform.parent.transform.GetChild(partNr-1).gameObject.GetComponent<Collider>(), GetComponent<Collider>());
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(this.transform.position.y<=-2) {
			//centipede reaches ground
			UnityEngine.Object.Destroy (this.gameObject);
		}


		//self destruction if lifes gone
		if (Gameplay.lives < 1) {
			Instantiate(MushroomGeneration.mushroomPublic, this.gameObject.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy (this.gameObject);
		}


		//index of part in centipede
		if(partNr!=transform.GetSiblingIndex()){
			partNr=transform.GetSiblingIndex();
			IndexChanged (partNr);
		}

		//head
		if (partNr == 0) {
			//Ebene tiefer
			if (transform.position.y > currentHeight) {
				target = new Vector3 (transform.position.x, currentHeight, transform.position.z);
				direction = 0;

			} else if(direction==0) {
				//4 random directions
				System.Random random = new System.Random();
				bool errorDir = true;

				//check if direction is possible/direction leads into playfield
				while (errorDir) {
					direction = random.Next (1, 5);
					if (direction == 1&&transform.position.x<playfieldSize)
					errorDir = false;
					if (direction == 2&&transform.position.x>-playfieldSize)
					errorDir = false;
					if (direction == 3&&transform.position.z<playfieldSize)
					errorDir = false;
					if (direction == 4&&transform.position.z>-playfieldSize)
					errorDir = false;
				}
				if (direction == 1)
				target = new Vector3 (playfieldSize, transform.position.y, transform.position.z);
				if (direction == 2)
				target = new Vector3 (-playfieldSize, transform.position.y, transform.position.z);
				if (direction == 3)
				target = new Vector3 (transform.position.x, transform.position.y, playfieldSize);
				if (direction == 4)
				target = new Vector3 (transform.position.x, transform.position.y, -playfieldSize);
			}

			//detect wall "collosion"
			bool wall1=transform.position.x > playfieldSize;
			bool wall2 = transform.position.x < -playfieldSize;
			bool wall3 = transform.position.z > playfieldSize;
			bool wall4 = transform.position.z < -playfieldSize;
			if (wall1 || wall2 || wall3 || wall4) {
				MoveDown();
				if (wall1)
				target=new Vector3 (playfieldSize-1,transform.position.y,transform.position.z);
				if (wall2)
				target=new Vector3 (-playfieldSize+1,transform.position.y,transform.position.z);
				if (wall3)
				target=new Vector3 (transform.position.x,transform.position.y,playfieldSize-1);
				if (wall4)
				target=new Vector3 (transform.position.x,transform.position.y,-playfieldSize+1);

			} 


			//dir to target
			var dir = target - transform.position;

			//Rotate towards part ahead and move
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (dir), Time.deltaTime * speed);
			transform.position += transform.forward * Time.deltaTime * speed;

			//update spotlight
			/*lightGameObject.transform.position = new Vector3(30, 5, 30);
			var dirToCent = transform.position-lightGameObject.transform.position;
			lightGameObject.transform.rotation = Quaternion.LookRotation(dirToCent);
			*/


		}

		//non-head
		else {
			//part ahead
			GameObject ahead =transform.parent.transform.GetChild(partNr-1).gameObject;

			//dir to part ahead
			var dir = ahead.transform.position - transform.position;

			//if distance to high
			if(dir.magnitude >= 0.8f)
			{
				//Rotate towards part ahead and move
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), dir.magnitude * Time.deltaTime*speed*1.5f);
				transform.position += transform.forward * dir.magnitude * Time.deltaTime*speed*1.5f;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		//disable self collision
		if (collision.collider.gameObject.transform.parent != transform.parent) {
		
			//touching ground--> loose life
			if (collision.collider.name == "Ground") {
				Gameplay.lives--;
				currentHeight = -15;
			} else {
				//bullet hit
				if (collision.collider.name == "Bullet_0" || collision.collider.name == "Bullet_1" ||collision.collider.name == "Bullet_2" || collision.collider.name == "Bullet_3") {
					//normal body parts
					if (partNr != 0) {

						if (collision.collider.name == "Bullet_0")Gameplay.scores[0] +=3;
						if (collision.collider.name == "Bullet_1")Gameplay.scores[1] +=3;
						if (collision.collider.name == "Bullet_2")Gameplay.scores[2] +=3;
						if (collision.collider.name == "Bullet_3")Gameplay.scores[3] +=3;

						//if not last
						if (transform.GetSiblingIndex () + 1 != transform.parent.childCount) {
							//create new centipede container
							GameObject centipede = new GameObject ();
							centipede.name = "Centipede-" + partNr;
							centipede.transform.parent = transform.parent.transform.parent.transform;

							//put parts into new centipede
							int timesIt = transform.parent.childCount;
							for (int i = partNr + 1; i < timesIt; i++) {
								//immer part+1 da sich index des Childs durch verschieben des vorherigen ändert
								transform.parent.transform.GetChild (partNr + 1).gameObject.transform.parent = centipede.transform;
							}
						}

						//loose part on bullet enter
						Instantiate (MushroomGeneration.mushroomPublic, this.gameObject.transform.position, Quaternion.identity);	
						CentipedeHitSoundObject.audio.Play();
						UnityEngine.Object.Destroy (this.gameObject);
					}					
					//head
					else {					
						if (collision.collider.name == "Bullet_0")Gameplay.scores[0] +=5;
						if (collision.collider.name == "Bullet_1")Gameplay.scores[1] +=5;
						if (collision.collider.name == "Bullet_2")Gameplay.scores[2] +=5;
						if (collision.collider.name == "Bullet_3")Gameplay.scores[3] +=5;

						Instantiate(MushroomGeneration.mushroomPublic, transform.parent.transform.GetChild (transform.parent.childCount - 1).gameObject.transform.position, Quaternion.identity);	
						CentipedeHitSoundObject.audio.Play();
						UnityEngine.Object.Destroy (transform.parent.transform.GetChild (transform.parent.childCount - 1).gameObject);
					}
				} else {
					//move down on collision with mushroom
					MoveDown ();
				}
			}
		}
	}

	void MoveDown(){
		if (partNr == 0) {
			if (currentHeight > -10) {
				if (transform.position.y <= currentHeight) {
					currentHeight--;
				}
				if (currentHeight < 3) {
					currentHeight = -15;
				}
			} 
		}
	}
}
