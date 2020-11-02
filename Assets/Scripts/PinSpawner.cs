using UnityEngine;
using System.Collections;

public class PinSpawner : MonoBehaviour {

	public int pinAmount;

	[Range(0.0f,1.0f)]
	public float spawnHeight;

	public Transform Pin_Green;
	public Transform Pin_Red;

	private Vector3 spawnPoint;
	private float sphereRadius;

	// DEBUGGING VARIABLES
	private GameObject[] getCount; // array for storing all pin-clones to get the total amount 
	private int pinCount; // total amount of pin clones
	private GameObject PinControllerScript;

		// Use this for initialization
		void Start () {
		pinAmount = (int)GameObject.Find("Scriptholder").GetComponent<MainManager>().pinAmount;
		Debug.Log("<<<<<<<<<<<<<<<<"+pinAmount+">>>>>>>>>>>>>>>>");

		sphereRadius = (gameObject.transform.localScale.x/2); // grabs dimensions of sphere / 2 = radius

			do{
				getCount = GameObject.FindGameObjectsWithTag("Pin");
				pinCount = getCount.Length;

				spawnPoint = GetComponent<Rigidbody>().velocity = Random.onUnitSphere * sphereRadius; // spawns pins along the surface of a (unit-sphere * sphere radius)
				
				if(spawnPoint.y > 0.0f && spawnPoint.y < (spawnHeight * sphereRadius)){ // if pin location (spawn point) is between zero and user-defined height:
					Instantiate(Pin_Green, spawnPoint, Quaternion.identity); // spawn green pin-clone at spawnPoint-location
				}

				spawnPoint = GetComponent<Rigidbody>().velocity = Random.onUnitSphere * sphereRadius;
				if(spawnPoint.y > 0.0f && spawnPoint.y < (spawnHeight * sphereRadius)){
					Instantiate(Pin_Red, spawnPoint, Quaternion.identity);
				}

			} while(pinAmount >= (pinCount+1)); // keep spawning while pins in scene is less than defined pin amount
	
		Debug.Log("Number of pins in scene: "+pinCount);
		}

		// Update is called once per frame
		void Update () {

		}
	}
