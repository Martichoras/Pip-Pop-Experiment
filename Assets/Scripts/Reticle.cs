using UnityEngine;
using System.Collections;
using System;

public class Reticle : MonoBehaviour {

	//public Camera camera;
	//public float lerpDuration = 2.5f; // 2.5 seconds
	private Vector3 initialScale;
	public bool pinFound = false;
	private bool isOpen = false;
	private Vector3 previousPos;
	public float taskCompletionTime;
	private GameObject scripth;
	private float currentTime;
	private GameObject MainManager;

	void Start () {
		pinFound = false;
		initialScale = transform.localScale;

		scripth = GameObject.Find("Scriptholder");
	}
	
	// Update is called once per frame
	void Update () {

		// a stereoscopic image of reticle is that it creates a double image making it hard to aim.
		RaycastHit hit;
		float distance;
		if (Physics.Raycast (new Ray(Camera.main.transform.position, Camera.main.transform.rotation * Vector3.forward), out hit)) {
			distance = hit.distance;
		} else { 
			distance = Camera.main.farClipPlane * 0.95f; //
		}

		transform.LookAt (Camera.main.transform.position); //rotate towards the camera
		transform.Rotate(0.0f, 180.0f,0.0f); // Reticle is a quad, so it needs to be reversed so the 'normal' side is visible
		transform.position = Camera.main.transform.position + Camera.main.transform.rotation * Vector3.forward * distance;
		transform.localScale = initialScale * distance; // sets scale of quad by the original scale*dist. scaling is performed linarly with with distance

		if (OVRInput.GetDown (OVRInput.Button.One)) {
			Debug.Log ("REMOTE PRESSED");
		}



		if(Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.One)){
			PinButtonPressed();
			taskCompletionTime = scripth.GetComponent<MainManager>().GetTime();
			taskCompletionTime = (float)System.Math.Round((double)taskCompletionTime,2);
		}

		//Debug.Log(taskCompletionTime);

		if(hit.rigidbody != null){
			if(hit.rigidbody.tag == "PipPopPin" && isOpen){
				Debug.Log("- Pin found! -\nTime: "+Time.time);
				pinFound = true;
				scripth.GetComponent<MainManager>().setTCT(taskCompletionTime);
			} 
		}

		if(pinFound){
			Application.LoadLevel("2_Final");
		}

	}

	public void PinButtonPressed(){
		StartCoroutine("Countdown", 10.0f);

	}

	private IEnumerator Countdown(float countdownTime)
	{	
		isOpen = true;
		yield return new WaitForSeconds(countdownTime);
		isOpen = false;
	}

}
