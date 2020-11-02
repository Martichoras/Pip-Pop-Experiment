using UnityEngine;
using System.Collections;

public class RandomBlink : MonoBehaviour {

	//Material change between. Set in Inspector
	public Material material1;
	public Material material2;

	//Coroutine variables
	private bool isTrue = true;
	//private bool randomOnOff;
	private int frequencyAdjust;

	//Getters for the MainManager
	public bool distractors;
	private float blinkFrequency;
	private GameObject Scriptholder;

	// Use this for initialization
	void Start () {

		Scriptholder = GameObject.Find("Scriptholder");
		distractors = Scriptholder.GetComponent<MainManager>().useDistractors;



		if(distractors){
			StartCoroutine(Flasher());
			//Debug.Log("Distractors are enabled");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Flasher(){
		while(isTrue){
			
			frequencyAdjust = Random.Range(1,4); // selects a random value between 1 and 4
			blinkFrequency = Random.Range(1,20); 
			blinkFrequency = (blinkFrequency/frequencyAdjust)*2;
			Debug.Log("blinkFrequency: "+blinkFrequency);
			GetComponent<MeshRenderer>().material = material1;
			yield return new WaitForSeconds(blinkFrequency); //  gives a random 
			
			blinkFrequency = Random.Range(1,20);
			//frequencyAdjust = Random.Range(1,4);

			GetComponent<MeshRenderer>().material = material2;
			yield return new WaitForSeconds(blinkFrequency);
			//}
		}
	}
		
}

