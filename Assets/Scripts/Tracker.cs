using UnityEngine;
using System.Collections;

public class Tracker : MonoBehaviour {

	[Header("This script is used for distance-based attenuation,\n measuring the distance between this game-object (reticle) and the singleton")]
	[Space(25)]

	public float distance;
	//public static Tracker instance = null;
	// Use this for initialization

	void Awake(){
	//if (instance == null)
	//	instance = this;
	//else if (instance != this)
	//	Destroy (GameObject);
	}


	void Start () {
		//DontDestroyOnLoad(this); // make this object constant for all scenes i.e. saving
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.transform.position + Camera.main.transform.rotation * Vector3.forward * distance;
	}
}
