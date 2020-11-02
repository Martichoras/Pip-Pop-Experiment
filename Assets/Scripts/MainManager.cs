using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

	public float currentTime;
	//public Canvas SettingsPanel;
	//private GameObject SettingsPanel;
	private bool isActive;
	public float pinAmount;
	public float blinkFrequency;
	public float attenuationValue;

	private Text pinAmountUpdate;
	private Text freqAmountUpdate;
	private Slider pinSlider;
	private Slider freqSlider;
	private Dropdown attenuationSelect;
	private InputField IDinput;
	public string participantID;
	public string savedID;

	private CanvasGroup SettingsCanvasGroup;
	private CanvasGroup ConditionCanvasGroup;

	public bool useDistractors;
	public bool isProximityDependent;

	private GameObject reticle;
	public float tct;
	private GameObject tmp;

	private GameObject datalogging;

	//avoiding duplicates..
	private GameObject[] getCount;
	private int dupCount;

	void Awake(){

		DontDestroyOnLoad(this);
	}

	void Start(){

		datalogging = GameObject.Find("LoggingHolder");

		//Access Pinslider
		if(Application.loadedLevelName == "1_Main"){
			pinSlider = GameObject.Find("PinSlider").GetComponent<Slider>();
			pinAmount = (pinSlider.value - pinSlider.value % 50); // increments with 50
			//pinAmount = pinSlider.value;
			pinAmountUpdate = GameObject.Find("PinAmountUpdate").GetComponent<Text>();

			freqSlider = GameObject.Find("FreqSlider").GetComponent<Slider>();
			blinkFrequency = freqSlider.value;
			freqAmountUpdate = GameObject.Find("FreqAmountUpdate").GetComponent<Text>();

			IDinput = GameObject.Find("InputField").GetComponent<InputField>();
		

			attenuationSelect = GameObject.Find("AttenuationDropdown").GetComponent<Dropdown>();
			attenuationValue = attenuationSelect.value;
		}

		// Access and disable Settings canvas
		SettingsCanvasGroup = GameObject.Find("SettingsCanvasGroup").GetComponent<CanvasGroup>();
		SettingsCanvasGroup.alpha = 0;
		SettingsCanvasGroup.blocksRaycasts = false;

		ConditionCanvasGroup = GameObject.Find("ConditionCanvasGroup").GetComponent<CanvasGroup>();


		//reticle = GameObject.Find("Reticle");
		savedID = datalogging.GetComponent<DataLogging>().GetID();



		if(savedID != null){
			IDinput.text = savedID;
			}else{
				IDinput.text = null;
			}


	}


	void FixedUpdate(){
			
		pinAmount = (pinSlider.value - pinSlider.value % 50); // increments with 50
		//pinAmount = pinSlider.value;
		pinAmountUpdate.text = pinAmount.ToString();
		blinkFrequency = freqSlider.value;
		blinkFrequency = (float)System.Math.Round((double)blinkFrequency,2);

		attenuationValue = attenuationSelect.value;
		//Debug.Log(attenuationValue);
		freqAmountUpdate.text = blinkFrequency.ToString();


		currentTime += Time.deltaTime;
		currentTime = (float)System.Math.Round((double)currentTime,2);
		//GetTime();

		if(Application.loadedLevelName == "1_Main"){

			// GET DISTRACTOR BOOL
			useDistractors = GameObject.Find("DistractorToggle").GetComponent<Toggle>().isOn;
			// USE PROXIMITY BOOL
			isProximityDependent = GameObject.Find("ProximityToggle").GetComponent<Toggle>().isOn;
			currentTime = 0.0f;
		}


		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

	
	
	}

	public void A_Button(){

	Application.LoadLevel("Condition_1_NoSound");
	participantID = IDinput.text;
	}

	public void B_Button(){
		
		Application.LoadLevel("Condition_2_Stereo");
		participantID = IDinput.text;
		//Debug.Log("Button pressed");
	}

	public void C_Button(){
		
		Application.LoadLevel("Condition_3_Bineural");
		participantID = IDinput.text;
		//Debug.Log("Button pressed");
	}

	public void Restart(){
		
		Application.LoadLevel("1_Main");
		participantID = IDinput.text;
		//SceneManager.LoadScene (1); new <<

		//Debug.Log("Button pressed");
	}

	public void Settings(){

		ConditionCanvasGroup.alpha = 0;
		ConditionCanvasGroup.blocksRaycasts = false;

		SettingsCanvasGroup.alpha = 1;
		SettingsCanvasGroup.blocksRaycasts = true;
	}

	public void SaveSettings(){

		SettingsCanvasGroup.alpha = 0;
		SettingsCanvasGroup.blocksRaycasts = false;

		ConditionCanvasGroup.alpha = 1;
		ConditionCanvasGroup.blocksRaycasts = true;
	}


	public float GetTime(){
		
		currentTime += Time.deltaTime;
		return (float)System.Math.Round((double)currentTime,2);
	}

	public float GetTCT(){

		return tct;
	}

	public float setTCT(float input){
		tct = input;
		return tct;
	}
						

}
