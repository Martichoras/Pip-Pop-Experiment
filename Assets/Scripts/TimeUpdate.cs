using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TimeUpdate : MonoBehaviour {

	private Text completionTimeText;
	private string guiText;
	private float currentTime;
	private GameObject Scriptholder;
	private GameObject Reticle;
	private float tct;
		
	// Use this for initialization
	void Start () {

		//Reticle = GameObject.Find("Reticle");
		//tct = Reticle.GetComponent<Reticle>().taskCompletionTime;
		//DontDestroyOnLoad(this);

		completionTimeText = GameObject.Find("Completion").GetComponent<Text>();
		Scriptholder = GameObject.Find("Scriptholder");
		currentTime = Scriptholder.GetComponent<MainManager>().GetTCT();
		completionTimeText.text = "Completion time: "+currentTime.ToString();

		Debug.Log("Time stopped at click: "+Scriptholder.GetComponent<MainManager>().GetTCT()+"\nTime at end of scene: "+Scriptholder.GetComponent<MainManager>().GetTime());
	}

	public void Restart(){

		Application.LoadLevel("1_Main");

		//Debug.Log("Button pressed");
	}

	public void Quit(){
		Application.Quit();
		Debug.Log("Quitting program...");
	}
		
}
